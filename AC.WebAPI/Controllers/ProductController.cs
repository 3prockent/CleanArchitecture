namespace AC.WebAPI.Controllers;

using CA.Application.Products.Commands;
using CA.Application.Products.Queries;
using CA.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;


[Route("api/Product")]
[ApiController]
public class ProductController : BaseApiController
{
    public ProductController(IMediator mediator) : base(mediator) { }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts(CancellationToken ct)
    {
        return Ok(await Mediator.Send(new GetAllProductsQuery(), ct));
    }

    [HttpGet, Route("{id}")]
    public async Task<ActionResult<Product>> GetProductById(Guid id, CancellationToken ct)
    {
        return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }, ct));
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(CreateProductCommand command, CancellationToken ct)
    {
        return Ok(await Mediator.Send(command, ct));
    }


    [HttpDelete("{id}", Name = "DeleteProduct")]
    public async Task<IActionResult> DeleteProductById(Guid id, CancellationToken ct)
    {
        return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }, ct));
    }


}