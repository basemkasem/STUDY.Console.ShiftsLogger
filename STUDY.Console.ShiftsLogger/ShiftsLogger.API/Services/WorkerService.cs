using Microsoft.EntityFrameworkCore;
using ShiftsLogger.API.Data;
using ShiftsLogger.API.Models;

namespace ShiftsLogger.API.Services;

public interface IWorkerService
{
    Task<Worker> AddWorkerAsync(Worker worker);
    Task<Worker?> GetWorkerByIdAsync(int id);
    Task<Worker?> UpdateWorkerAsync(int id, Worker worker);
    Task<bool> DeleteWorkerAsync(int id);
    Task<List<Worker>?> GetAllWorkersAsync();
}
public class WorkerService : IWorkerService
{
    private readonly AppDbContext _context;
    public WorkerService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Worker> AddWorkerAsync(Worker worker)
    {
        _context.Workers.Add(worker);
        await _context.SaveChangesAsync();
        return worker;
    }

    public async Task<bool> DeleteWorkerAsync(int id)
    {
        var worker = await GetWorkerByIdAsync(id);
        if (worker is null)
        {
            return false;
        }

        _context.Workers.Remove(worker);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Worker>?> GetAllWorkersAsync()
    {
        return await _context.Workers.Include(w => w.Shifts).ToListAsync();
    }

    public async Task<Worker?> GetWorkerByIdAsync(int id)
    {
        return await _context.Workers.FindAsync(id);
    }

    public async Task<Worker?> UpdateWorkerAsync(int id, Worker updatedWorker)
    {
        var worker = await GetWorkerByIdAsync(id);
        if (worker is null)
        {
            return null;
        }
        
        _context.Entry(worker).CurrentValues.SetValues(updatedWorker);
        await _context.SaveChangesAsync();
        return worker;
    }
}
