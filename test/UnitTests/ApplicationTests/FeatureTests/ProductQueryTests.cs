using Clean.Application.Features.Products.Queries.GetProducts;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Products;
using Clean.Domain.Products.Enums;
using Clean.Domain.Shared;
using Moq;

namespace ApplicationTests.FeatureTests;

public class ProductQueryTests
{
    private readonly GetProductsHandler _getProductsHandler;
    private readonly Mock<IQueryUnitOfWork> _moq;
    public ProductQueryTests()
    {
        _moq = new Mock<IQueryUnitOfWork>();
        _getProductsHandler = new GetProductsHandler(_moq.Object);

    }

    [Fact]
    public async Task GetProducts_ShouldBe_Returns_Values()
    {
        var products = new List<Product>();
        Product product = new("TestProduct");
        product.AddMoney(Currency.TL, 1000);
        product.AddCategory("TestCategory");
        product.AddInventory(product.Id, 100);
        products.Add(product);

        List<GetProductsResponse> expectedResult = products.Select(p => new GetProductsResponse(
            p.Id.ToString(), 
            p.DisplayName, 
            p.Price.Currency.ToString(), 
            p.Price.Amount, 
            p.Category.DisplayName)).ToList();
        

         _moq.Setup(x => x.Product.GetAllProductsWithInventoryAsync(50,5,1,default).Result).Returns(products);

        TResult<GetProductsResponse> actualResult = await _getProductsHandler.Handle(new GetProductsRequest(50,5,1), default);

        Assert.True(actualResult.IsSuccessed);
        Assert.Equal<GetProductsResponse>(expectedResult, actualResult.Values);


    }
}
