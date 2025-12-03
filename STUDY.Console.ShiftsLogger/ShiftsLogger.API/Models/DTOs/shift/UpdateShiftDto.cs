namespace ShiftsLogger.API.Models.DTOs.shift;

public class UpdateShiftDto
{
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
}
