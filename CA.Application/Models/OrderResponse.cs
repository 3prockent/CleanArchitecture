namespace CA.Application.Models;

using CA.Domain.Entities;

public class OrderResponse
{
    public IEnumerable<Order> value { get; set; }
}
