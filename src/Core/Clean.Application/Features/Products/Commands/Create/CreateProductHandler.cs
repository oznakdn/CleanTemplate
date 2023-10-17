using Clean.Application.Results;
using Clean.Domain.Products;
using Clean.Domain.Repositories;

namespace Clean.Application.Features.Products.Commands.Create;


public record CreateProductRequest(string DisplayName, MoneyType MoneyType, decimal Amount, string CategoryName, int Quantity) : IRequest<CreateProductResponse>;
public class CreateProductResponse : Response { }

public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
{
    private readonly IProductRepository _product;
    private readonly AddInventoryEventHandler _addInventoryEvent;
    public CreateProductHandler(IProductRepository product, AddInventoryEventHandler addInventoryEvent)
    {
        _product = product;
        _addInventoryEvent = addInventoryEvent;
    }

    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        Product product = new(request.DisplayName);
        product.AddMoney(request.MoneyType, request.Amount);
        product.AddCategory(request.CategoryName);


        Inventory inventory = await _addInventoryEvent.Publish(new AddInventoryEvent(product.Id,request.Quantity),cancellationToken);
        product.AddInventory(inventory);

        _product.Insert(product);

        await _product.SaveAsync(cancellationToken);
        return new CreateProductResponse
        {
            Successed = true,
            Message = "Product was added."
        };
    }
}
