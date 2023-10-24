using Clean.Application.Results;
using Clean.Application.UnitOfWork.Commands;
using Clean.Domain.Products;

namespace Clean.Application.Features.Products.Commands.Create;


public record CreateProductRequest(string DisplayName, Currency currency, decimal Amount, string CategoryName, int Quantity) : IRequest<IDataResult<CreateProductResponse>>;
public class CreateProductResponse : Response { }

public class CreateProductHandler : IRequestHandler<CreateProductRequest, IDataResult<CreateProductResponse>>
{

    private readonly ICommandUnitOfWork _command;
    private readonly AddInventoryEventHandler _addInventoryEvent;
    public CreateProductHandler(ICommandUnitOfWork command, AddInventoryEventHandler addInventoryEvent)
    {
        _command = command;
        _addInventoryEvent = addInventoryEvent;
    }

    public async Task<IDataResult<CreateProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var errors = new List<string>();

        Product product = new(request.DisplayName);
        var categoryResult = product.AddCategory(request.CategoryName);
        var productResult = product.AddMoney(request.currency, request.Amount);

        var inventoryResult = product.AddInventory(product.Id,request.Quantity);
        await _addInventoryEvent.Publish(new AddInventoryEvent(product.Id, request.Quantity), cancellationToken);

        if(categoryResult.IsFailed)
        {
            errors.Add(categoryResult.Message);
        }

        if (productResult.IsFailed)
        {
            errors.Add(productResult.Message);
        }

        if (inventoryResult.IsFailed)
        {
            errors.Add(inventoryResult.Message);
        }

        if (errors.Count > 0)
        {
            return new DataResult<CreateProductResponse>(errors, false);
        }

        _command.Product.Insert(product);
        await _command.Product.ExecuteAsync(cancellationToken);

        return new DataResult<CreateProductResponse>("Product was added.", true);
    }
}
