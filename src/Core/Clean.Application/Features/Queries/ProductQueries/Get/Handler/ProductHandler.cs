﻿using Clean.Application.Features.Queries.ProductQueries.Get.Dtos;

namespace Clean.Application.Features.Queries.ProductQueries.Get.Handler;

public class ProductHandler : IRequestHandler<ProductRequest, List<ProductResponse>>
{
    private readonly IEfUnitOfWork _efUnitOfWork;
    public ProductHandler(IEfUnitOfWork efUnitOfWork)
    {
        _efUnitOfWork = efUnitOfWork;
    }

    public async Task<List<ProductResponse>> Handle(ProductRequest request, CancellationToken cancellationToken)
    {
        var products = await _efUnitOfWork.Product.GetAllAsync(cancellationToken);
        var result = _efUnitOfWork.Mapper.Map<IEnumerable<ProductResponse>>(products);
        return result.ToList();
    }
}
