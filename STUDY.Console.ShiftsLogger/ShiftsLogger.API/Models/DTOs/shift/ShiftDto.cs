namespace ShiftsLogger.API.Models.DTOs.shift;

public class ShiftDto
{
    public int Id { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
}
