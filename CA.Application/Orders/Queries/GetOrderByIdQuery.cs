using CA.Application.Interfaces;
using CA.Domain.Entities;
using CA.Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Orders.Queries
{
    public class GetOrderByIdQuery : IRequest<Result<Order>>
    {
        public Guid Id { get; set; }
        public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<Order>>
        {
            private readonly IDbContext _context;
            public GetOrderByIdQueryHandler(IDbContext context)
            {
                _context = context;
            }
            public async Task<Result<Order>> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
            {

                var product = await _context.Orders.Where(a => a.Id == query.Id).FirstOrDefaultAsync(cancellationToken);
                if (product == null)
                {
                    return Result.Failure<Order>(new Error(
                        "Order.NotFound",
                        $"The Order with Id {query.Id} NotFound"));
                }
                return product;
            }


        }
    }
}
