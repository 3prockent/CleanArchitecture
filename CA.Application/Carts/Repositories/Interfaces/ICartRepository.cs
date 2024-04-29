namespace CA.Application.Repositories;

using CA.Domain.Entities;
using CA.Domain.Shared;

public interface ICartRepository
{
    Task<CartInfo> GetCartInfo(string userName);
    Task<CartInfo> UpdateCart(CartInfo cart);
    Task DeleteCart(string userName);
}

