namespace Business.Models;

public class Customer
{
    public int Id { get; set; }   
    public string Name { get; set; } = string.Empty;

    public string OurReference { get; set; } = string.Empty;
}