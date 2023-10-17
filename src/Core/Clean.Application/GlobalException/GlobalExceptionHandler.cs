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
            _logger.Information($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            string message = ex.Message.ToString();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new ExceptionResponse(statusCode: context.Response.StatusCode, message);
            _logger.Fail($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode} - {ex.Message}");
            await context.Response.WriteAsJsonAsync<ExceptionResponse>(response);
        }
    }
}
