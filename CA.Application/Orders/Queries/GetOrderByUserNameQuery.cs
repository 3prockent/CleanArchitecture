namespace CA.Application.Orders.Queries;

using CA.Application.Interfaces;
using CA.Domain.Entities;
using CA.Domain.Errors;
using CA.Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;


public class GetOrderByUserNameQuery : IRequest<Result<List<Order>>>
{
    public String UserName { get; set; }
    public class GetOrderByUserNameQueryHandler : IRequestHandler<GetOrderByUserNameQuery, Result<List<Order>>>
    {
        private readonly IDbContext _context;
        public GetOrderByUserNameQueryHandler(IDbContext context)
        {
            _context = context;
        }
        public async Task<Result<List<Order>>> Handle(GetOrderByUserNameQuery query, CancellationToken cancellationToken)
        {

            var products = await _context.Orders.Where(order => order.UserName == query.UserName).ToListAsync(cancellationToken);
            if (products.Count == 0)
            {
                return Result.Failure<List<Order>>(OrderErrors.NotFoundByUser(query.UserName));
            }
            return products;
        }


    }
}
