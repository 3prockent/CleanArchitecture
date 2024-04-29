namespace CA.Application.Orders.Queries;

using CA.Application.Interfaces;
using CA.Domain.Entities;
using CA.Domain.Errors;
using CA.Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

            var product = await _context.Orders.FirstOrDefaultAsync(order => order.Id == query.Id, cancellationToken);
            if (product == null)
            {
                return Result.Failure<Order>(OrderErrors.NotFound(query.Id));
            }
            return product;
        }


    }
}
