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
    public async Task GetCustomers_ShouldBe_Return_Customers()
    {
        var customers = new List<Customer>();
        var result = Customer.CreateCustomer("TestName", "TestSurname", "test@mail.com", "5001002030", "123456");
        customers.Add(result.Value);

        _moq.Setup(m => m.Customer.GetCustomersAsync(default).Result).Returns(customers);

        var actualResult = customers.Select(x => new GetCustomersResponse(x.Id.ToString(), x.FirstName, x.LastName, x.Email, x.PhoneNumber));

        var expectedResult = await _customersHandler.Handle(new GetCustomersRequest(), default);


        Assert.Equal<GetCustomersResponse>(expectedResult.Values, actualResult);

    }
}
