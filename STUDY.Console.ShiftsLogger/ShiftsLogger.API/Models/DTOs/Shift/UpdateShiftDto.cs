namespace ShiftsLogger.API.Models.DTOs.Shift;

public class UpdateShiftDto
{
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
}
