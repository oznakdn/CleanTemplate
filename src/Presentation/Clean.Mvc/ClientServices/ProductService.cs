using Clean.Domain.Shared;
using Clean.Mvc.Models.Product;

namespace Clean.Mvc.ClientServices;

public class ProductService : ClientService
{
    HttpClient _client;
    public ProductService(IHttpClientFactory httpClient) : base(httpClient)
    {
        _client = _httpClient.CreateClient("CleanClient");
    }

    public async Task<TResult<GetProductsModel>> GetProductsAsync()
    {
        string url = $"products/getproducts";
        HttpResponseMessage responseMessage = await _client.GetAsync(url);
        GetProductsModel? response =  await responseMessage.Content.ReadFromJsonAsync<GetProductsModel>();
        return TResult<GetProductsModel>.Ok(response!);
    }
}
