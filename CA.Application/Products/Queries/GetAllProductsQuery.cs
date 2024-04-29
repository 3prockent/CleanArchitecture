namespace CA.Application.Products.Queries;

using CA.Application.Abstractions.Messaging;
using CA.Domain.Entities;
using CA.Domain.Errors;
using CA.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using CA.Application.Interfaces;
using MediatR;

public record GetAllProductsQuery : IRequest<Result<IEnumerable<Product>>> { }

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Result<IEnumerable<Product>>>
{
    private readonly IDbContext _context;


    public GetAllProductsQueryHandler(IDbContext context)
    {
        _context = context;
    }
    public async Task<Result<IEnumerable<Product>>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }
}

