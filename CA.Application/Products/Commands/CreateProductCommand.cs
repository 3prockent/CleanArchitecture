namespace CA.Application.Products.Commands;

using CA.Application.Abstractions.Messaging;
using CA.Domain.Entities;
using CA.Domain.Errors;
using CA.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using CA.Application.Interfaces;

public class CreateProductCommand : ICommand<Guid>
{
    public string? Name { get; set; }
    public string? Category { get; set; }
    public string? Summary { get; set; }
    public decimal Price { get; set; }
    public int Qty { get; set; }
}


internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
{
    private readonly IDbContext _context;
    public CreateProductCommandHandler(IDbContext context)
    {
        _context = context;
    }
    public async Task<Result<Guid>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        if (String.IsNullOrEmpty(command.Name))
            return Result.Failure<Guid>(ProductErrors.Empty("Name"));
        if (String.IsNullOrEmpty(command.Category))
            return Result.Failure<Guid>(ProductErrors.Empty("Category"));
        if (await _context.Products.AnyAsync(x => x.Name == command.Name, cancellationToken))
            return Result.Failure<Guid>(ProductErrors.AlreadyExist(command.Name));
        var product = new Product()
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Category = command.Category,
            Summary = command.Summary,
            Price = command.Price
        };
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync();
        return product.Id;
    }
}
