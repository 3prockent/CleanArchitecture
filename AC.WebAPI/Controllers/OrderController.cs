namespace AC.WebAPI.Controllers;

using CA.Application.Orders.Commands;
using CA.Application.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


[Route("api/orders")]
[ApiController]
public class OrderController : BaseApiController
{
    public OrderController(IMediator mediator) : base(mediator) { }
    [HttpGet, Route("{skip?}/{count?}")]
    public async Task<IActionResult> GetAll(int? count, int? skip, CancellationToken ct)
    {
        return Ok(await Mediator.Send(new GetAllOrdersQuery(count, skip), ct));
    }

    [HttpGet, Route("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        return Ok(await Mediator.Send(new GetOrderByIdQuery { Id = id }, ct));
    }

    [HttpGet, Route("GetByUsername/{username}")]
    public async Task<IActionResult> GetByUserName(string username, CancellationToken ct)
    {
        return Ok(await Mediator.Send(new GetOrderByUserNameQuery { UserName = username }, ct));
    }

    [HttpPost, Route("")]
    public async Task<IActionResult> Create(CreateOrderCommand command, CancellationToken ct)
    {
        return Ok(await Mediator.Send(command, ct));
    }

    [HttpDelete, Route("")]
    public async Task<IActionResult> Delete(DeleteOrderCommand command, CancellationToken ct)
    {
        return Ok(await Mediator.Send(command, ct));
    }
}

