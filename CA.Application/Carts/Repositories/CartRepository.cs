namespace CA.Application.Repositories;

using CA.Domain.Entities;
using CA.Domain.Shared;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;



public class CartRepository : ICartRepository
{
    private readonly IDistributedCache _redisCache;

    public CartRepository(IDistributedCache cache)
    {
        _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<CartInfo?> GetCartInfo(string userName)
    {
        var cartInfo = await _redisCache.GetStringAsync(userName);

        if (String.IsNullOrEmpty(cartInfo))
            return null;

        return JsonConvert.DeserializeObject<CartInfo>(cartInfo);
    }
    
    public async Task<CartInfo> UpdateCart(CartInfo cartInfo)
    {
        await _redisCache.SetStringAsync(cartInfo.UserName, JsonConvert.SerializeObject(cartInfo));
        
        return await GetCartInfo(cartInfo.UserName);
    }

    public async Task DeleteCart(string userName)
    {
        await _redisCache.RemoveAsync(userName);
    }

}
