using CA.Application.Interfaces;
using CA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Orders.Queries
{
    public record GetAllOrdersQuery : IRequest<IEnumerable<Order>>;

    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
    {
        private readonly IDbContext _context;
        public GetAllOrdersQueryHandler(IDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
        {
            return await _context.Orders.ToListAsync();
   
        }
    }
}
