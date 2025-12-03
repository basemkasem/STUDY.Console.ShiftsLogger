namespace ShiftsLogger.API.Models.DTOs.shift;

public class CreateShiftDto
{
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public int WorkerId { get; set; }
}
