

namespace cleanarchitecture.Api.Controllers;

using Microsoft.AspNetCore.Diagnostics;
using cleanarchitecture.Application.Common.Errors;
public class ErrorsController : ControllerBase
{
    [Route("/error")]

    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        var (statusCode,message) = exception switch
        {
          
              IServiceException serviceException => ((int)serviceException.StatusCode,serviceException.ErrorMessage),
            _ =>(StatusCodes.Status500InternalServerError,"An unexpected error occured"),
        };
        return Problem(statusCode: statusCode,detail: message);
    }

}