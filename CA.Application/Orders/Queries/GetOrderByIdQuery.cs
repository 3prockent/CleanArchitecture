using CA.Application.Interfaces;
using CA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Orders.Queries
{
        public class GetOrderByIdQuery : IRequest<Order>
        {
            public Guid Id { get; set; }
            public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
            {
                private readonly IDbContext _context;
                public GetOrderByIdQueryHandler(IDbContext context)
                {
                    _context = context;
                }
                public async Task<Order> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
                {
                    var product = _context.Orders.Where(a => a.Id == query.Id).FirstOrDefault();
                    return product;
                }


        }
        }
}
