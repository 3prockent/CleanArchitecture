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
                //if (String.IsNullOrEmpty(command.Number))
                //    return Result
                //if_context.Orders.Any(co)) { }
                var product = new Order()
                {
                    ContactName = command.ContactName,
                    Number = command.Number,
                    Comment = command.Comment,
                    Amount = command.Amount
                };
                _context.Orders.Add(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
