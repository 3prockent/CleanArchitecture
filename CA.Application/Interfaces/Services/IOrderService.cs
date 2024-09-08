namespace CA.Application.Interfaces;

using CA.Application.Models;
using CA.Domain.Entities;
using System.Threading.Tasks;


public interface IOrderService
{
    IEnumerable<Order> GetOrdersByUserName(string userName);
}
