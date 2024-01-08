using Clean.Application.UnitOfWork.Commands;
using Clean.Domain.Products;
using Clean.Domain.Products.Enums;
using Clean.Domain.Products.ValueObjects;
using Clean.Shared;


namespace Clean.Application.Features.Products.Commands.Create;


public record CreateProductRequest(string DisplayName, Currency currency,Image image, decimal Amount, string CategoryName, int Quantity) : IRequest<IResult<CreateProductResponse>>;
public record CreateProductResponse;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, IResult<CreateProductResponse>>
{

    private readonly ICommandUnitOfWork _command;
    private readonly AddInventoryEventHandler _addInventoryEvent;
    public CreateProductHandler(ICommandUnitOfWork command, AddInventoryEventHandler addInventoryEvent)
    {
        _command = command;
        _addInventoryEvent = addInventoryEvent;
    }

    public async Task<IResult<CreateProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var errors = new List<string>();

        Product product = new(request.DisplayName);
        var categoryResult = product.AddCategory(request.CategoryName);
        var productResult = product.AddMoney(request.currency, request.Amount);
        product.AddImage(new Image(request.image.ImageName, request.image.ImageSize));

        var inventoryResult = product.AddInventory(product.Id,request.Quantity);
        _addInventoryEvent.Publish(new AddInventoryEvent(product.Id, request.Quantity));

        if(!categoryResult.IsSuccess)
        {
            errors.Add(categoryResult.Message);
        }

        if (!productResult.IsSuccess)
        {
            errors.Add(productResult.Message);
        }

        if (!inventoryResult.IsSuccess)
        {
            errors.Add(inventoryResult.Message);
        }

        if (errors.Count > 0)
        {
            return  Result<CreateProductResponse>.Fail(errors:errors);
        }

        _command.Product.Insert(product);
        await _command.Product.ExecuteAsync(cancellationToken);

        return  Result<CreateProductResponse>.Success("Product was added.");
    }
}
