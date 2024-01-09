using Clean.Shared;
using Clean.WebRazorPages.Models.AuthModels;
using Clean.WebRazorPages.Pages.Admin.Auth.Models;

namespace Clean.WebRazorPages.Services;

public class AuthService : ClientServiceBase
{
    public AuthService(EndPoints EndPoints, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext) : base(EndPoints, clientFactory, httpContext)
    {
    }

    public async Task<IResult<LoginResponse>> Login(LoginRequest loginRequest)
    {
        string? url = EndPoints.Auth.Login;

        HttpResponseMessage responseMessage = await HttpClient.PutAsJsonAsync(url, loginRequest);
        if (responseMessage.IsSuccessStatusCode)
        {
            LoginResponse? response = await responseMessage.Content.ReadFromJsonAsync<LoginResponse>();
            return Result<LoginResponse>.Success(value: response);
        }

        return Result<LoginResponse>.Fail();
    }
}
