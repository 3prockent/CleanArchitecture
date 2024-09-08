namespace CA.Domain.Entities;

public class ExpandedCartInfo : CartInfo
{
    public new List<ExpandedCartItem> Items { get; set; } = new List<ExpandedCartItem>();

}
