namespace CA.Domain.Entities;


public class ExpandedCartItem : CartItem
{
    //Product Related Additional Fields
    public string Category { get; set; }
    public string Summary { get; set; }

}
