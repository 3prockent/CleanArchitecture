using CA.Application.Abstractions.Messaging;
using CA.Application.Interfaces;
using CA.Application.Orders.Commands;
using CA.Domain.Entities;
using CA.Domain.Errors;
using CA.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Orders.Commands
{
    public class CreateOrderCommand : ICommand<Guid>
    {
        public string? ContactName { get; set; }
        public string? Number { get; set; }
        public string? Comment { get; set; }
        public decimal Amount { get; set; }
    }
}

internal class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, Guid>
{
    private readonly IDbContext _context;
    public CreateOrderCommandHandler(IDbContext context)
    {
        _context = context;
    }
    public async Task<Result<Guid>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        if (String.IsNullOrEmpty(command.Number))
            return Result.Failure<Guid>(DomainErrors.Order.EmptyNumber);
        if (_context.Orders.Any(x => x.Number == command.Number))
            return Result.Failure<Guid>(DomainErrors.Order.AlreadyExist(command.Number));
        var product = new Order()
        {
            Id = Guid.NewGuid(),
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
