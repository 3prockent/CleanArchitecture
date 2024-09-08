namespace CA.Application.Services;

using CA.Application.Interfaces;
using CA.Application.Repositories;
using CA.Domain.Entities;
using System;
using System.Net.Http;
using System.Threading.Tasks;


public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<ExpandedCartInfo> GetCart(string userName)
    {
        var cartInfo = _cartRepository.GetCartInfo(userName);
        var expandedCartInfo = new ExpandedCartInfo { UserName = userName };
        foreach (CartItem cartItem in cartInfo.Result.Items)
        {
            var expandedCartItem = new ExpandedCartItem
            {
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                Price = cartItem.Price,
                ProductName = cartItem.ProductName
            };

            expandedCartInfo.Items.Add(expandedCartItem);
        }
        return expandedCartInfo;
    }        
}
