namespace CA.Application.Interfaces;

using CA.Domain.Entities;
using System.Threading.Tasks;


public interface ICartService
{
    Task<ExpandedCartInfo> GetCart(string userName);
}
