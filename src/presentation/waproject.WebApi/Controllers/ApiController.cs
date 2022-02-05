using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace waproject.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private IMediator _mediator = default!;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
    }
}
