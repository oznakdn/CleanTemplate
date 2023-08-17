using Microsoft.AspNetCore.Http;
using System.Net;

namespace Clean.Application.GlobalException;

public class GlobalExceptionHandler : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            string message = ex.Message.ToString();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new ExceptionResponse(statusCode: context.Response.StatusCode, message);
            await context.Response.WriteAsJsonAsync<ExceptionResponse>(response);
        }
    }
}
