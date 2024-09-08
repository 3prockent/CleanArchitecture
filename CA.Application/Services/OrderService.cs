
using CA.Application.Interfaces;
using CA.Application.Orders.Queries;
using CA.Domain.Entities;
using MediatR;

namespace CA.Application.Services
{
    public class OrderService : IOrderService
    {
        public IMediator Mediator { get; set; }

        public OrderService(IMediator mediator)
        {
            Mediator = mediator;
        }

        IEnumerable<Order> IOrderService.GetOrdersByUserName(string userName)
        {
            return Mediator.Send(new GetOrderByUserNameQuery { UserName = userName }, new CancellationToken()).Result.Value;
        }
    }
}
