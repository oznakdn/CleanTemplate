using Clean.Application.UnitOfWork.Commands;
using Clean.Application.UnitOfWork.Queries;
using Clean.Domain.Products.Enums;
using Clean.Shared;

namespace Clean.Application.Features.Products.Commands.Update;

public record UpdateProductRequest(string Id, string? DisplayName, Currency? Currency, decimal? Amount, string? CategoryName) : IRequest<IResult<UpdateProductResponse>>;
public record UpdateProductResponse();

public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, IResult<UpdateProductResponse>>
{
    private readonly IQueryUnitOfWork _query;
    private readonly ICommandUnitOfWork _command;

    public UpdateProductHandler(IQueryUnitOfWork query, ICommandUnitOfWork command)
    {
        _query = query;
        _command = command;
    }

    public async Task<IResult<UpdateProductResponse>> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _query.Product.ReadSingleOrDefaultAsync(true, x => x.Id == Guid.Parse(request.Id), cancellationToken, x => x.Inventory);
        if (product is null)
        {
            return Result<UpdateProductResponse>.Fail("Product not found");
        }

        product.UpdateProductName(request.DisplayName);
        product.UpdateProductCategory(request.CategoryName!);
        product.UpdateProductMoneyCurrency(request.Currency);
        product.UpdateProductAmount(request.Amount);

        await _command.Product.UpdateAsync(product);
        await _command.Product.ExecuteAsync(cancellationToken);
        return Result<UpdateProductResponse>.Success("Product has been updated");
    }
}
