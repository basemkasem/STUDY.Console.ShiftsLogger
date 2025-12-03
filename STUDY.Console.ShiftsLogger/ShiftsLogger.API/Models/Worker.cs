namespace ShiftsLogger.API.Models;

public class Worker
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Shift> Shifts { get; set; } = new List<Shift>();
}
