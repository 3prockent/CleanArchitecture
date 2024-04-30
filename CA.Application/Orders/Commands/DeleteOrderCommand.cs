namespace CA.Application.Orders.Commands;


using CA.Application.Abstractions.Messaging;
using CA.Application.Interfaces;
using CA.Domain.Errors;
using CA.Domain.Shared;
using Microsoft.EntityFrameworkCore;

public class DeleteOrderCommand : ICommand<Guid>
{
    public Guid Id { get; set; }
}

internal class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand, Guid>
{
    private readonly IDbContext _context;
    public DeleteOrderCommandHandler(IDbContext context)
    {
        _context = context;
    }
    public async Task<Result<Guid>> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var orderToDelete = await _context.Orders.FirstOrDefaultAsync(order => order.Id == command.Id);
        if (orderToDelete == null)
        {
            return Result.Failure<Guid>(OrderErrors.NotFound(command.Id));
        }

        _context.Orders.Remove(orderToDelete);
        await _context.SaveChangesAsync();
        return command.Id;
    }
}
