using Clean.Domain.Shared;
using Clean.Mvc.Areas.Admin.Models.AuthViewModels;

namespace Clean.Mvc.ClientServices;

public class AuthService : ClientService
{

    HttpClient _client;
    public AuthService(IHttpClientFactory httpClient) : base(httpClient)
    {
        _client = _httpClient.CreateClient("CleanClient");
    }

    public async Task<TResult<LoginResponse>> LoginAsync(LoginRequest loginRequest)
    {
        string url = "auth/login";
        var responseMessage = await _client.PutAsJsonAsync<LoginRequest>(url, loginRequest);
        var response = await responseMessage.Content.ReadFromJsonAsync<LoginResponse>();
        return  TResult<LoginResponse>.Ok(response!);
    }
}
