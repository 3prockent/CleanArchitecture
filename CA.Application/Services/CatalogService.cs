
using CA.Application.Interfaces;
using CA.Application.Models;
using CA.Application.Products.Queries;
using CA.Domain.Entities;
using MediatR;



namespace CA.Application.Services;

public class CatalogService : ICatalogService
{

    public IMediator Mediator { get; set; }

    public CatalogService(IMediator mediator)
    {
        Mediator = mediator;
    }

    public async Task<IEnumerable<Product>> GetCatalog()
    {
        return Mediator.Send(new GetAllProductsQuery(), new CancellationToken()).Result.Value;
    }

    public async Task<Product> GetCatalog(Guid id)
    {
        return Mediator.Send(new GetProductByIdQuery { Id = id }, new CancellationToken()).Result.Value;
    }

    public async Task<IEnumerable<Product>> GetCatalogByCategory(string category)
    {
        //var response = await _client.GetAsync($"/api/v1/Catalog/GetProductByCategory/{category}");
        //return await response.ReadContentAs<List<CatalogModel>>();
        return null;
    }              
}
