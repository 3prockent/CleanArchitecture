namespace CA.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string? Summary { get; set; }
    public decimal Price { get; set; }
}
