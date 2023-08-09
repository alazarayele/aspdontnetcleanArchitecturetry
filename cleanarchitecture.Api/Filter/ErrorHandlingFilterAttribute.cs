using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace cleanarchitecture.Api;



public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
       

        var problemDetails = new ProblemDetails
        {   
            Title = "AN Erro Occured While Processing Your request",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Status = (int)HttpStatusCode.InternalServerError,
            
        };
        context.Result = new ObjectResult(problemDetails);
        
        context.ExceptionHandled = true;
    }
}