using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Vulder.SharedKernel.Middlewares;

public class ControllerActionLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ControllerActionLoggingMiddleware> _logger;

    public ControllerActionLoggingMiddleware(RequestDelegate next, ILogger<ControllerActionLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var message = $"{context.Request.Method} {context.Request.Path}{context.Request.QueryString}";
        _logger.LogInformation(21, "", message);

        await _next.Invoke(context);
    }
}