using Microsoft.AspNetCore.Http;
using System.Net;

namespace Clean.Application.GlobalException;

public class GlobalExceptionHandler : IMiddleware
{
    private readonly IEffectiveLog<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(IEffectiveLog<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            _logger.Information($"{DateTime.Now} - {context.Request.Method} - {context.Request.Path}");
            await next.Invoke(context);
            _logger.Information($"{DateTime.Now} - {context.Response.StatusCode} - {context.Request.Path}");
        }
        catch (Exception ex)
        {
            _logger.Information($"{DateTime.Now} - {context.Response.StatusCode} - {ex.Message}");
            string message = ex.Message.ToString();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new ExceptionResponse(statusCode: context.Response.StatusCode, message);
            await context.Response.WriteAsJsonAsync<ExceptionResponse>(response);
        }
    }
}
