namespace CA.Domain.Entities;
using System.Collections.Generic;


public class UserShoppingModel
{
    public string UserName { get; set; }
    public ExpandedCartInfo Cart { get; set; }
    public IEnumerable<Order> Orders { get; set; }
}
