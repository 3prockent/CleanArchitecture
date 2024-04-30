namespace CA.Application.Orders.Commands;


using CA.Application.Abstractions.Messaging;
using CA.Application.Interfaces;
using CA.Domain.Entities;
using CA.Domain.Errors;
using CA.Domain.Shared;
using Microsoft.EntityFrameworkCore;


public class CreateOrderCommand : ICommand<Guid>
{
    public string? UserName { get; set; }
    public decimal TotalAmount { get; set; }
    public string? OrderNumber { get; set; }
    public string? Comment { get; set; }

    //Personal info
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
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
    if (String.IsNullOrEmpty(command.OrderNumber))
        return Result.Failure<Guid>(OrderErrors.EmptyNumber);
    if (await _context.Orders.AnyAsync(x => x.OrderNumber == command.OrderNumber, cancellationToken))
        return Result.Failure<Guid>(OrderErrors.AlreadyExist(command.OrderNumber));
    var product = new Order()
    {
        Id = Guid.NewGuid(),
        UserName = command.UserName,
        OrderNumber = command.OrderNumber,
        Comment = command.Comment,
        TotalAmount = command.TotalAmount,
        FirstName = command.FirstName,
        LastName = command.LastName,
        EmailAddress = command.LastName
    };
    await _context.Orders.AddAsync(product, cancellationToken);
    await _context.SaveChangesAsync();
    return product.Id;
}
}
