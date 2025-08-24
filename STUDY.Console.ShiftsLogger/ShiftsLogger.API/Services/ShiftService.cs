using Microsoft.EntityFrameworkCore;
using ShiftsLogger.API.Data;
using ShiftsLogger.API.Models;

namespace ShiftsLogger.API.Services;

public interface IShiftService
{
    public Task<Shift> AddShiftAsync(Shift shift);
    public Task<IEnumerable<Shift>> GetAllShiftsAsync();
    public Task<Shift?> GetShiftByIdAsync(int id);
    public Task<bool> RemoveShift(int id);
}
public class ShiftService : IShiftService
{
    private readonly AppDbContext _Context;
    public ShiftService(AppDbContext appDbContext)
    {
        _Context = appDbContext;
    }

    public async Task<Shift> AddShiftAsync(Shift shift)
    {
        _Context.Shifts.Add(shift);
        await _Context.SaveChangesAsync();
        return shift;
    }

    public async Task<IEnumerable<Shift>> GetAllShiftsAsync()
    {
        return await _Context.Shifts.Include(s => s.Worker).ToListAsync();
    }

    public async Task<Shift?> GetShiftByIdAsync(int id)
    {
        return await _Context.Shifts.Include(s => s.Worker).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<bool> RemoveShift(int id)
    {
        var shift = await _Context.Shifts.FindAsync(id);
        if (shift is null) return false;
        _Context.Shifts.Remove(shift);
        await _Context.SaveChangesAsync();
        return true;
    }
}
