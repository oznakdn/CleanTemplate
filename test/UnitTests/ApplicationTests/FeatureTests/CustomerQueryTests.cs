using Clean.Application.Features.Customers.Queries.GetCustomers;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Customers;
using Moq;

namespace ApplicationTests.FeatureTests;

public class CustomerQueryTests
{

    private readonly Mock<IQueryUnitOfWork> _moq;
    private readonly GetCustomersHandler _customersHandler;
    public CustomerQueryTests()
    {
        _moq = new Mock<IQueryUnitOfWork>();
        _customersHandler = new GetCustomersHandler(_moq.Object);
    }


    [Fact]
    public void GetCustomers_ShouldBe_Return_Success()
    {
        var result = Customer.CreateCustomer("TestName", "TestSurname", "test@mail.com", "5001002030", "123456");
        Customer customer = result.Value;

        _moq.Setup(m => m.Customer.ReadSingle(true, x => x.Id == result.Value.Id)).Returns(customer);
        var handle = _customersHandler.Handle(new GetCustomersRequest(50, 1, 1), CancellationToken.None).Result;

        GetCustomersResponse actualResult = handle.Value;

        GetCustomersResponse expectedResult = new(customer.Id.ToString(), customer.FirstName, customer.LastName, customer.Email, customer.PhoneNumber);


        Assert.Equal<string>(expectedResult.Id, actualResult.Id);

    }
}
