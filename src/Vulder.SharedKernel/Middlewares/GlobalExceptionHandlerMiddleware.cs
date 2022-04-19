using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Vulder.SharedKernel.Exceptions;
using Vulder.SharedKernel.Models;

namespace Vulder.SharedKernel.Middlewares;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception e)
        {
            LogException(e);
            
            var vulderBaseException = (VulderBaseException)e;

            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)vulderBaseException.StatusCode;

            var responseBody = new ExceptionModel
            {
                StatusCode = (int)vulderBaseException.StatusCode,
                ErrorMessage = e.Message
            };

            await response.WriteAsync(JsonConvert.SerializeObject(responseBody));
        }
    }

    private void LogException(Exception exception)
        => _logger.LogError(22, exception, "An exception was thrown");
}