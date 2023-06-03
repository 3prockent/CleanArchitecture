using CA.Application.Interfaces;
using CA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Orders.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public string? ContactName { get; set; }
        public string? Number { get; set; }
        public string? Comment { get; set; }
        public decimal Amount { get; set; }
        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
        {
            private readonly IDbContext _context;
            public CreateOrderCommandHandler(IDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
            {
                var product = new Order();
                product.ContactName = command.ContactName;
                product.Number = command.Number;
                product.Comment = command.Comment;
                product.Amount = command.Amount;
                _context.Orders.Add(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
