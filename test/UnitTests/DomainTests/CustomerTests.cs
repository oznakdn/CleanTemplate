using Clean.Domain.Customers;
using Clean.Domain.Shared;

namespace DomainTests;

public class CustomerTests
{

    [Fact]
    public void CreateCustomer_When_Properties_Valid_Should_Return_Successed()
    {
        TResult<Customer> result = Customer.CreateCustomer("John","Doe","john@mail.com","5001002030","test123");
        Assert.True(result.IsSuccessed);
        
    }

    [Fact]
    public void CreateCustomer_When_Properties_Invalid_Should_Return_Failed()
    {
        TResult<Customer> result = Customer.CreateCustomer("John","","john@mail.com","5001002030","test123");
        Assert.True(result.IsFailed);
        Assert.Equal(result.Errors.Count(),1);
    }

    [Fact]
    public void AddAddress_When_Properties_Valid_Should_Return_Successed()
    {
        TResult<Customer> customerResult = Customer.CreateCustomer("John","Doe","john@mail.com","5001002030","test123");
        Result addressResult =  customerResult.Value.AddAddress("Home","Center",11,"California");
        Assert.True(addressResult.IsSuccessed);
    }

    [Fact]
    public void AddAddress_When_Properties_Valid_Should_Return_Failed()
    {
        TResult<Customer> customerResult = Customer.CreateCustomer("John","Doe","john@mail.com","5001002030","test123");
        Result addressResult =  customerResult.Value.AddAddress("Home","Center",-11,"");
        Assert.True(addressResult.IsFailed);
        Assert.Equal(addressResult.Errors.Count(),2);
    }

    [Fact]
    public void AddCreditCard_When_Properties_Valid_Should_Return_Successed()
    {
        TResult<Customer> customerResult = Customer.CreateCustomer("John","Doe","john@mail.com","5001002030","test123");
        Result creditCardResult =  customerResult.Value.AddCreditCard("John Doe","1111 2222 3333 4444","11/28","000",10_000);
        Assert.True(creditCardResult.IsSuccessed);
    }

    [Fact]
    public void AddCreditCard_When_Properties_Valid_Should_Return_Failed()
    {
       TResult<Customer> customerResult = Customer.CreateCustomer("John","Doe","john@mail.com","5001002030","test123");
        Result creditCardResult =  customerResult.Value.AddCreditCard("John Doe","","11/28","000",-10_000);
        Assert.True(creditCardResult.IsFailed);
        Assert.Equal(creditCardResult.Errors.Count(),2);

    }
}