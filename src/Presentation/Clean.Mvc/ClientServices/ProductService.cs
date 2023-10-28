using Clean.Mvc.Models.Product;

namespace Clean.Mvc.ClientServices;

public class ProductService : ClientService
{
    HttpClient _client;
    public ProductService(IHttpClientFactory httpClient) : base(httpClient)
    {
        _client = _httpClient.CreateClient("CleanClient");
    }

    public async Task<IEnumerable<GetProductsModel>> GetProductsAsync()
    {
        string url = $"products/getproducts";
        HttpResponseMessage res = await _client.GetAsync(url);

        return await res.Content.ReadFromJsonAsync<IEnumerable<GetProductsModel>>();
    }
}
