using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AC.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        public IMediator Mediator { get; set; }

        public BaseApiController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
