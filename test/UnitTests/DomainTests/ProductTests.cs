using Clean.Domain.Products;
using Clean.Domain.Products.Enums;

namespace DomainTests;

public class ProductTests
{

    [Fact]
    public void CreateProduct_ShouldBe_Return_NotNull()
    {
        Product product = new("TestProduct");
        Assert.NotNull(product);
        Assert.IsType<Guid>(product.Id);
    }

    [Fact]
    public void AddMoney_When_AmountGreaterThanZero_ShouldBe_Return_Successed()
    {
        Product product = new("TestProduct");
        var result = product.AddMoney(Currency.TL,1000);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void AddMoney_When_AmountLessThanZero_ShouldBe_Return_Failed()
    {
        Product product = new("TestProduct");
        var result = product.AddMoney(Currency.TL,-1000);
        Assert.True(!result.IsSuccess);
        Assert.Equal<int>(result.Errors.Count(),1);

    }

    [Fact]
    public void AddCategory_When_DisplayNameIsNotNullOrEmpty_ShouldBe_Return_Successed()
    {
        Product product = new("TestProduct");
        var result = product.AddCategory("TestCategory");
        Assert.True(result.IsSuccess);
    }


    [Fact]
    public void AddCategory_When_DisplayNameIsNullOrEmpty_ShouldBe_Return_Failed()
    {
        Product product = new("TestProduct");
        var result = product.AddCategory("");
        Assert.True(!result.IsSuccess);
        Assert.Equal<string>(result.Message,"DisplayName can be between 3 and 20 characters!");
    }

    [Fact]
    public void AddInventory_When_QuantityGreaterThanZero_ShouldBe_Return_Successed()
    {
        Product product = new("TestProduct");
        var result = product.AddInventory(product.Id,1);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void AddInventory_When_QuantityLessThanZero_ShouldBe_Return_Failed()
    {
        Product product = new("TestProduct");
        var result = product.AddInventory(product.Id,-1);
        Assert.True(!result.IsSuccess);
    }




}