namespace AC.WebAPI.Controllers;

using CA.Application.Repositories;
using CA.Domain.Entities;
using CA.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using CA.Domain.Errors;

[Route("api/Cart")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartRepository _repository;
    //private readonly IPublishEndpoint _publishEndpoint;
    //private readonly IMapper _mapper;

    //public CartController(ICartRepository repository, IPublishEndpoint publishEndpoint, IMapper mapper)

    public CartController(ICartRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        //_publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet("{userName}", Name = "GetCart")]
    public async Task<ActionResult<CartInfo>> GetCart(string userName)
    {
        var cart = await _repository.GetCartInfo(userName);
        return Ok(cart ?? new CartInfo(userName));
    }

    [HttpPost]
    public async Task<ActionResult<CartInfo>> UpdateCart([FromBody] CartInfo cart)
    {
        return Ok(await _repository.UpdateCart(cart));
    }

    [HttpDelete("{userName}", Name = "DeleteCart")]        
    public async Task<IActionResult> DeleteCart(string userName)
    {
        await _repository.DeleteCart(userName);
        return Ok(userName);
    }

    [Route("[action]")]
    [HttpPost]
    public async Task<Result> Checkout([FromBody] CartCheckout cartCheckout)
    {
        // get existing cart with total price            
        // Set TotalPrice on cartCheckout eventMessage
        // send checkout event to rabbitmq
        // remove the cart

        // get existing cart with total price
        var cart = await _repository.GetCartInfo(cartCheckout.UserName);
        if (cart == null)
        {
            return Result.Failure(CartErrors.Empty());
        }

        // send checkout event to rabbitmq
        //var eventMessage = _mapper.Map<CartCheckoutEvent>(cartCheckout);
        //eventMessage.TotalPrice = cart.TotalPrice;
        //await _publishEndpoint.Publish<CartCheckoutEvent>(eventMessage);

        // remove the cart
        await _repository.DeleteCart(cart.UserName);

        return Result.Success<String>(cart.UserName);
    }
}
