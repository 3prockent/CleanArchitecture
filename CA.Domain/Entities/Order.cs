namespace CA.Domain.Entities;

public class Order : BaseEntity
{
    public string? UserName { get; set; }
    public decimal TotalAmount { get; set; }
    public string? OrderNumber { get; set; }
    public string? Comment { get; set; }

    //Personal info
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
}
