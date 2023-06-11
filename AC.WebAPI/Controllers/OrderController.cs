using CA.Application.Orders.Commands;
using CA.Application.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AC.WebAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : BaseApiController
    {
        public OrderController(IMediator mediator) : base(mediator) {}
        [HttpGet, Route("")]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await Mediator.Send(new GetAllOrdersQuery(), ct));
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            return Ok(await Mediator.Send(new GetOrderByIdQuery { Id = id }, ct));
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Create(CreateOrderCommand command, CancellationToken ct)
        {
            return Ok(await Mediator.Send(command, ct));
        }
    }
}
