using Clean.Shared;
using Clean.WebRazorPages.Models.ProductModels;

namespace Clean.WebRazorPages.Services;

public class ProductService : ClientServiceBase
{
    public ProductService(EndPoints EndPoints, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext) : base(EndPoints, clientFactory, httpContext)
    {
    }

    public async Task<IResult<ProductsResponse>> GetProductsAsync()
    {

        string? url = EndPoints.Product.GetProducts;
        HttpResponseMessage responseMessage = await HttpClient.GetAsync(url);
        if (responseMessage.IsSuccessStatusCode)
        {
            IEnumerable<ProductsResponse>? response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<ProductsResponse>>();
            return Result<ProductsResponse>.Success(values: response!);

        }

        return Result<ProductsResponse>.Fail();

    }

    public async Task<IResult<ProductDetailResponse>> GetProductDetailAsync(string productId)
    {
        string? url = $"{EndPoints.Product.GetProductDetail}/{productId}";
        bool isAdded = base.AddAuthenticationHeader();
        if (isAdded)
        {
            HttpResponseMessage responseMessage = await HttpClient.GetAsync(url);
            ProductDetailResponse? response = await responseMessage.Content.ReadFromJsonAsync<ProductDetailResponse>();
            return Result<ProductDetailResponse>.Success(value: response);
        }

        return Result<ProductDetailResponse>.Fail();
    }

    public async Task<IResult<string>> InsertProductAsync(InsertProductRequest insertProduct)
    {
        string? url = EndPoints.Product.CreateProduct;
        bool isAdded = base.AddAuthenticationHeader();

        if (isAdded)
        {
            HttpResponseMessage responseMessage = await HttpClient.PostAsJsonAsync<InsertProductRequest>(url,insertProduct);
            string response = await responseMessage.Content.ReadAsStringAsync();
            return Result<string>.Success(value: response);
        }

        return Result<string>.Fail();
    }

    public async Task<IResult<string>>UpdateProductAsync(UpdateProductRequest updateProduct)
    {
        string url = EndPoints.Product.UpdateProduct;
        bool isAdded = base.AddAuthenticationHeader();

        if (isAdded)
        {
            HttpResponseMessage responseMessage = await HttpClient.PutAsJsonAsync<UpdateProductRequest>(url, updateProduct);
            string response = await responseMessage.Content.ReadAsStringAsync();
            return Result<string>.Success(value: response);
        }

        return Result<string>.Fail();
    }

}
