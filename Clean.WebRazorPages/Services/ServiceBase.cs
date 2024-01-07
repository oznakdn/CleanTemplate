using System.Net.Http.Headers;

namespace Clean.WebRazorPages.Services;

public abstract class ServiceBase
{
    protected EndPoints EndPoints { get; }
    protected HttpClient HttpClient { get; }

    private readonly IHttpContextAccessor _httpContext;
    protected ServiceBase(EndPoints EndPoints, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext)
    {
        this.EndPoints = EndPoints;
        HttpClient = clientFactory.CreateClient("CleanClient");
        _httpContext = httpContext;
    }

    protected virtual void AddAuthenticationHeader()
    {
        string? token = _httpContext.HttpContext!.Request.Cookies["token"];

        if (!string.IsNullOrEmpty(token))
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }

}
