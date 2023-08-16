using MongoDB.Bson.Serialization.Attributes;

namespace Clean.Application.Features.Commands.Customers.Add.Dtos;

public class AddCustomerRequest : IRequest<AddCustomerResponse>
{
    public string FullName { get; set; }
    public string Email { get; set; }
}
