using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AC.WebAPI.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator? _mediator;

        public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }

}
