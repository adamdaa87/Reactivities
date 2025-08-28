using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException("Mediator service is not registered.");
        
        // You can add common functionality for all controllers here, such as logging, error handling, etc.
        // For example, you could override the OnActionExecuting method to log requests.
    }
}
