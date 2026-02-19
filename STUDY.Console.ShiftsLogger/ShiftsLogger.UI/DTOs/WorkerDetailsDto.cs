namespace ShiftsLogger.UI.DTOs;

public class WorkerDetailsDto
{
    public string Name { get; set; } = null!;
    public IReadOnlyList<ShiftDto> Shifts { get; set; } = [];
}