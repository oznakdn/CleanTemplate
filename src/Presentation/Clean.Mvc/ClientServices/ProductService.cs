using Clean.Mvc.Models.Product;
using Clean.Shared;

namespace Clean.Mvc.ClientServices;

public class ProductService : ClientService
{
    HttpClient _client;
    public ProductService(IHttpClientFactory httpClient) : base(httpClient)
    {
        _client = _httpClient.CreateClient("CleanClient");
    }

    public async Task<IResult<GetProductsModel>> GetProductsAsync()
    {
        string url = $"products/getproducts";
        HttpResponseMessage responseMessage = await _client.GetAsync(url);
        var response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<GetProductsModel>>();
        return Result<GetProductsModel>.Success(values: response);
    }
}
