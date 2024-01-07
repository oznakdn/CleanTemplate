using Clean.Domain.Shared;
using Clean.WebRazorPages.Pages.Product;

namespace Clean.WebRazorPages.Services;

public class ProductService : ServiceBase
{
    public ProductService(EndPoints EndPoints, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext) : base(EndPoints, clientFactory, httpContext)
    {
    }

    public async Task<TResult<ProductsResponse>>GetProductsAsync()
    {
        string? url = base.EndPoints.Product[0].GetProducts;
        base.AddAuthenticationHeader();
        HttpResponseMessage responseMessage = await HttpClient.GetAsync(url);
        IEnumerable<ProductsResponse>? response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<ProductsResponse>>();
        return TResult<ProductsResponse>.Ok(response!);
    }

}
