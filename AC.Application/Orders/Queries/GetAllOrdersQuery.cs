using AC.Application.Interfaces;
using AC.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AC.Application.Orders.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {

        
    }
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
