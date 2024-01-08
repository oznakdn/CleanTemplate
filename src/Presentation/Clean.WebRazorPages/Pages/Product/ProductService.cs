using Clean.Domain.Shared;
using Clean.WebRazorPages.Pages.Product.Models;

namespace Clean.WebRazorPages.Pages.Product;

public class ProductService : ClientServiceBase
{
    public ProductService(EndPoints EndPoints, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext) : base(EndPoints, clientFactory, httpContext)
    {
    }

    public async Task<TResult<ProductsResponse>> GetProductsAsync()
    {
        string? url = base.EndPoints.Product[0].GetProducts;
        bool isAdded = base.AddAuthenticationHeader();
        if(isAdded)
        {
            HttpResponseMessage responseMessage = await HttpClient.GetAsync(url);
            IEnumerable<ProductsResponse>? response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<ProductsResponse>>();
            return TResult<ProductsResponse>.Ok(response!);
        }

        return TResult<ProductsResponse>.Fail();
        
    }

}
