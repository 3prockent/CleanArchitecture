using Microsoft.AspNetCore.Mvc;
using System.Net;
using CA.Domain.Entities;
using CA.Application.Interfaces;
using CA.Application.Models;

namespace AC.WebAPI.Controllers
{
    [ApiController]
    [Route("Shopping")]
    public class ShoppingController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ICatalogService _catalogService;
        private readonly IOrderService _orderService;

        public ShoppingController(ICatalogService catalogService, ICartService cartService, IOrderService orderService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet("{userName}", Name = "GetUserShopping")]
        [ProducesResponseType(typeof(UserShoppingModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserShoppingModel>> GetUserShopping(string userName)
        {
            await Console.Out.WriteLineAsync("start method");
            Console.WriteLine("sadasd");
            var cart = await _cartService.GetCart(userName);

            foreach (var item in cart.Items)
            {
                var product = await _catalogService.GetCatalog(item.ProductId);

                // set additional product fields
                item.ProductName = product.Name;
                item.Category = product.Category;
                item.Summary = product.Summary;
            }            

            var orders = _orderService.GetOrdersByUserName(userName);

            var shoppingModel = new UserShoppingModel
            {
                UserName = userName,
                
                Cart = cart,
                Orders = orders
            };
            
            return Ok(shoppingModel);
        }

    }
}
