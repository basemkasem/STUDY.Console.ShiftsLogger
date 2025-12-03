namespace ShiftsLogger.API.Models.DTOs.shift;

public class GetShiftDto
{
    public int Id { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public int? WorkerId { get; set; }
    public required string WorkerName { get; set; }
}