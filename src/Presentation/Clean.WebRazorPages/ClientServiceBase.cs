using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace Clean.WebRazorPages;

public abstract class ClientServiceBase
{
    protected EndPoints EndPoints { get; }
    protected HttpClient HttpClient { get; }

    private readonly IHttpContextAccessor _httpContext;
    protected ClientServiceBase(EndPoints EndPoints, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext)
    {
        this.EndPoints = EndPoints;
        HttpClient = clientFactory.CreateClient("CleanClient");
        _httpContext = httpContext;
    }

    protected virtual bool AddAuthenticationHeader()
    {
        string? token = _httpContext.HttpContext!.Request.Cookies["token"];

        if (!string.IsNullOrEmpty(token))
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return true;
        }

        return false;
    }

}

