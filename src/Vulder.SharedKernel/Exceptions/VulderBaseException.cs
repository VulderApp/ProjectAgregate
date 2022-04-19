using System;
using System.Net;

namespace Vulder.SharedKernel.Exceptions;

public abstract class VulderBaseException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }
    
    protected VulderBaseException(string message) : base(message)
    {
    }
}