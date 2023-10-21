using Clean.Application.Results;
using Clean.Application.UnitOfWork.Commands;
using Clean.Domain.Products;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Products.Commands.Create;


public record CreateProductRequest(string DisplayName, Currency currency, decimal Amount, string CategoryName, int Quantity) : IRequest<CreateProductResponse>;
public class CreateProductResponse : Response { }

public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
{

    private readonly ICommandUnitOfWork _command;
    private readonly AddInventoryEventHandler _addInventoryEvent;
    public CreateProductHandler(ICommandUnitOfWork command, AddInventoryEventHandler addInventoryEvent)
    {
        _command = command;
        _addInventoryEvent = addInventoryEvent;
    }

    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        Product product = new(request.DisplayName);
        product.AddMoney(request.currency, request.Amount);
        product.AddCategory(request.CategoryName);


        Inventory inventory = await _addInventoryEvent.Publish(new AddInventoryEvent(product.Id, request.Quantity), cancellationToken);
        product.AddInventory(inventory);

        _command.Product.Insert(product);

        await _command.Product.ExecuteAsync(cancellationToken);
        return new CreateProductResponse
        {
            Successed = true,
            Message = "Product was added."
        };
    }
}
