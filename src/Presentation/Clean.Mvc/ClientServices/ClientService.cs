namespace Clean.Mvc.ClientServices;

public class ClientService
{
    protected readonly IHttpClientFactory _httpClient;

    public ClientService(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient;
    }
}
