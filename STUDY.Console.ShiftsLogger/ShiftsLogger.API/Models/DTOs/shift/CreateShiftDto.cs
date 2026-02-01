using System.ComponentModel.DataAnnotations;

namespace ShiftsLogger.API.Models.DTOs.shift;

public class CreateShiftDto
{
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    [Required]
    public int WorkerId { get; set; }
}
