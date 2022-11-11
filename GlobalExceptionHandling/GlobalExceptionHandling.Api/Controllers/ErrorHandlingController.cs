using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GlobalExceptionHandling.Api.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    public class ErrorHandlingController : ControllerBase
    {
        public IActionResult HandleError()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = exceptionHandlerFeature.Error;

            if(exception is NotFoundException notFoundException)
            {
                return Problem(notFoundException.Message, null, 404);
            }

            return Problem("Uh oh");
        }
    }
}