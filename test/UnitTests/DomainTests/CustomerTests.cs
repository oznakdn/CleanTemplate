using Clean.Domain.Customers;
using Clean.Shared;

namespace DomainTests;

public class CustomerTests
{

    [Fact]
    public void CreateCustomer_When_Properties_Valid_Should_Return_Successed()
    {
        IResult<Customer> result = Customer.CreateCustomer("John","Doe","john@mail.com","5001002030","test123");
        Assert.True(result.IsSuccess);
        
    }

    [Fact]
    public void CreateCustomer_When_Properties_Invalid_Should_Return_Failed()
    {
        IResult<Customer> result = Customer.CreateCustomer("John","","john@mail.com","5001002030","test123");
        Assert.True(result.IsSuccess);
        Assert.Equal(result.Errors.Count(),1);
    }

    [Fact]
    public void AddAddress_When_Properties_Valid_Should_Return_Successed()
    {
        IResult<Customer> customerResult = Customer.CreateCustomer("John","Doe","john@mail.com","5001002030","test123");
        IResult addressResult =  customerResult.Value.AddAddress("Home","Center",11,"California");
        Assert.True(addressResult.IsSuccess);
    }

    [Fact]
    public void AddAddress_When_Properties_Valid_Should_Return_Failed()
    {
        IResult<Customer> customerResult = Customer.CreateCustomer("John","Doe","john@mail.com","5001002030","test123");
        IResult addressResult =  customerResult.Value.AddAddress("Home","Center",-11,"");
        Assert.False(addressResult.IsSuccess);
        Assert.Equal(addressResult.Errors.Count(),2);
    }

    [Fact]
    public void AddCreditCard_When_Properties_Valid_Should_Return_Successed()
    {
        IResult<Customer> customerResult = Customer.CreateCustomer("John","Doe","john@mail.com","5001002030","test123");
        IResult creditCardResult =  customerResult.Value.AddCreditCard("John Doe","1111 2222 3333 4444","11/28","000",10_000);
        Assert.False(creditCardResult.IsSuccess);
    }

    [Fact]
    public void AddCreditCard_When_Properties_Valid_Should_Return_Failed()
    {
       IResult<Customer> customerResult = Customer.CreateCustomer("John","Doe","john@mail.com","5001002030","test123");
        IResult creditCardResult =  customerResult.Value.AddCreditCard("John Doe","","11/28","000",-10_000);
        Assert.False(creditCardResult.IsSuccess);
        Assert.Equal(creditCardResult.Errors.Count(),2);

    }
}