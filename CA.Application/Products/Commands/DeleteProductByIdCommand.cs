namespace CA.Application.Products.Commands;

using CA.Application.Abstractions.Messaging;
using CA.Domain.Entities;
using CA.Domain.Errors;
using CA.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using CA.Application.Interfaces;

public class DeleteProductByIdCommand : ICommand<Guid>
{
    public Guid Id { get; set; }
}


internal class DeleteProductByIdCommandHandler : ICommandHandler<DeleteProductByIdCommand, Guid>
{
    private readonly IDbContext _context;
    public DeleteProductByIdCommandHandler(IDbContext context)
    {
        _context = context;
    }
    public async Task<Result<Guid>> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
    {
        if (command.Id.Equals(Guid.Empty))
            return Result.Failure<Guid>(ProductErrors.Empty("Id"));

        var productToDelete = await _context.Products.FirstOrDefaultAsync(product => product.Id == command.Id, cancellationToken);

        if (productToDelete == null)
        {
            return Result.Failure<Guid>(ProductErrors.NotFound(command.Id));
        }
        
        _context.Products.Remove(productToDelete);
        await _context.SaveChangesAsync();
        return Result.Success<Guid>(productToDelete.Id);
    }
}
