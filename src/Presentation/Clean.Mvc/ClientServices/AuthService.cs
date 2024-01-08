using Clean.Mvc.Areas.Admin.Models.AuthViewModels;
using Clean.Shared;

namespace Clean.Mvc.ClientServices;

public class AuthService : ClientService
{

    HttpClient _client;
    public AuthService(IHttpClientFactory httpClient) : base(httpClient)
    {
        _client = _httpClient.CreateClient("CleanClient");
    }

    public async Task<IResult<LoginResponse>> LoginAsync(LoginRequest loginRequest)
    {
        string url = "auth/login";
        var responseMessage = await _client.PutAsJsonAsync<LoginRequest>(url, loginRequest);
        LoginResponse? response = await responseMessage.Content.ReadFromJsonAsync<LoginResponse>();
        return  Result<LoginResponse>.Success(value:response!);
    }
}
