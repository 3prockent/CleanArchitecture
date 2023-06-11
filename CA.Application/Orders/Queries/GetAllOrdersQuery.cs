using CA.Application.Interfaces;
using CA.Domain.Entities;
using CA.Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Orders.Queries
{
    public record GetAllOrdersQuery : IRequest<Result<IEnumerable<Order>>>;

    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, Result<IEnumerable<Order>>>
    {
        private readonly IDbContext _context;
        public GetAllOrdersQueryHandler(IDbContext context)
        {
            _context = context;
        }
        public async Task<Result<IEnumerable<Order>>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
        {
            return await _context.Orders.ToListAsync(cancellationToken);
   
        }
    }
}
