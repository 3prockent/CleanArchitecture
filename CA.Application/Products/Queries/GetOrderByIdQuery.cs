namespace CA.Application.Products.Queries;

using CA.Application.Abstractions.Messaging;
using CA.Domain.Entities;
using CA.Domain.Errors;
using CA.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using CA.Application.Interfaces;
using MediatR;


public record GetProductByIdQuery : IRequest<Result<Product>> {
    public Guid Id { get; set; }

}

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<Product>>
{
    private readonly IDbContext _context;


    public GetProductByIdQueryHandler(IDbContext context)
    {
        _context = context;
    }
    public async Task<Result<Product>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == query.Id, cancellationToken);
        if (product == null)
        {
            return Result.Failure<Product>(ProductErrors.NotFound(query.Id));
        }
        return product;
    }
}