namespace CA.Application.Orders.Queries;

using CA.Application.Interfaces;
using CA.Domain.Entities;
using CA.Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;


public class GetAllOrdersQuery : IRequest<Result<IEnumerable<Order>>>
{
    public int? TakeCount { get; set; } = 10;
    public int? SkipCount { get; set; } = 0;
    public GetAllOrdersQuery(int? take, int? skip)
    {
        if (take != null)
            TakeCount = take;
        if (skip != null)
            SkipCount = skip;
    }
}

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, Result<IEnumerable<Order>>>
{
    private readonly IDbContext _context;


    public GetAllOrdersQueryHandler(IDbContext context)
    {
        _context = context;
    }
    public async Task<Result<IEnumerable<Order>>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
    {
        return await _context.Orders.Skip(query.SkipCount.Value).Take(query.TakeCount.Value).ToListAsync(cancellationToken);
    }
}
