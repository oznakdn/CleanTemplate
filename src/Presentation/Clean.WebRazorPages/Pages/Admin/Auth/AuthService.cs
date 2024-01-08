using Clean.Domain.Shared;
using Clean.WebRazorPages.Pages.Admin.Auth.Models;

namespace Clean.WebRazorPages.Pages.Admin.Auth;

public class AuthService : ClientServiceBase
{
    public AuthService(EndPoints EndPoints, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext) : base(EndPoints, clientFactory, httpContext)
    {
    }

    public async Task<TResult<LoginResponse>> Login(LoginRequest loginRequest)
    {
        string? url = EndPoints.Auth[0].Login;

        HttpResponseMessage responseMessage = await HttpClient.PutAsJsonAsync<LoginRequest>(url, loginRequest);
        if (responseMessage.IsSuccessStatusCode)
        {
            LoginResponse? response = await responseMessage.Content.ReadFromJsonAsync<LoginResponse>();
            return TResult<LoginResponse>.Ok(response);
        }

        return TResult<LoginResponse>.Fail();
    }
}
