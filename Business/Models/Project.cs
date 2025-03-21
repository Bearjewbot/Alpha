namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Customer Customer { get; set; } = null!;

    public Budget Budget { get; set; } = null!;

    public StatusType Status { get; set; } = null!;

    public Timetable Dates { get; set; } = null!;
}