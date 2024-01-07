using Microsoft.AspNetCore.Http;
using System.Net;
using Gleeman.EffectiveLogger.ConsoleFile.Interfaces;

namespace Clean.Application.GlobalException;

public class GlobalExceptionHandler : IMiddleware
{
    private readonly IEffectiveLogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(IEffectiveLogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            
            await next.Invoke(context);
            switch (context.Response.StatusCode)
            {
                case 200: _logger.Info($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
                    break;
                case 201:
                    _logger.Info($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
                    break;
                case 204:
                    _logger.Info($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
                    break;
                case 400:
                    _logger.Fail($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
                    break;
                case 401:
                    _logger.Fail($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
                    break;
                case 403:
                    _logger.Fail($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
                    break;
                case 404: _logger.Fail($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
                    break;
                default:
                    _logger.Warning($"{context.Request.Method} - {context.Request.Path} - {context.Response.StatusCode}");
                    break;
            }
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
