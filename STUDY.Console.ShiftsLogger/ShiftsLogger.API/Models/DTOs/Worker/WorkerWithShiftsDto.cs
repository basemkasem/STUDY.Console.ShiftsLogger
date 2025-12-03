using ShiftsLogger.API.Models.DTOs.shift;

namespace ShiftsLogger.API.Models.DTOs.Worker;

public class WorkerWithShiftsDto
{
    public int WorkerId { get; set; }
    public string Name { get; set; } = null!;
    public List<ShiftDto> Shifts { get; set; } = new();
}
