using System.Net;

namespace Vulder.SharedKernel.Exceptions;

public class AuthException : VulderBaseException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    
    public AuthException(string message = "Unable to authorize user") : base(message)
    {
    }
}