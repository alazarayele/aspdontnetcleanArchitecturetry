using System.Net;

namespace cleanarchitecture.Application.Common.Errors;

public class DeplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Email already exists";
}