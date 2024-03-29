﻿using Clean.Application.Features.Products.Commands.Create;
using Clean.Application.Features.Products.Commands.Update;
using Clean.Application.Features.Products.Queries.GetProductDetail;
using Clean.Application.Features.Products.Queries.GetProducts;
using Clean.Application.Features.Products.Queries.GetProductsWithDataShaping;
using Clean.Persistence.Caching;
using Microsoft.AspNetCore.RateLimiting;
using MongoDB.Driver;

namespace Clean.Api.Controllers;

[Route("api/products")]
public class ProductsController : AbstractController
{
    private readonly IProductCacheService _productCache;

    public ProductsController(IMediator mediator, IProductCacheService productCache) : base(mediator)
    {
        _productCache = productCache;
    }



    [HttpGet]
    [EnableRateLimiting("Api")]
    public async Task<IActionResult> GetProducts([FromQuery] int PageSize, [FromQuery] int PageNumber, [FromQuery] string? Query)
    {
        var result = await _mediator.Send(new GetProductsRequest(50, PageSize, PageNumber, Query));
        return Ok(result.Values);
    }


    [HttpGet("get-cache")]
    public IActionResult GetProductsCache()
    {
        var result = _productCache.GetProductFromCache();
        return Ok(result);
    }


    [HttpGet("product-detail/{productId}")]
    public async Task<IActionResult> GetProductDetail(string productId)
    {
        var result = await _mediator.Send(new GetProductDetailRequest(productId));
        if (!result.IsSuccess) return NotFound(result.Message);
        return Ok(result.Value);
    }

    [HttpGet("data-shaping")]
    public async Task<IActionResult> GetProductsWithDataShaping([FromQuery] string fields)
    {
        var result = await _mediator.Send(new GetProductsDataShapingRequest(fields));
        return Ok(result.Values);
    }


    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest createProduct)
    {
        var result = await _mediator.Send(createProduct);
        if (!result.IsSuccess && result.Errors.Count() > 0)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result.Message);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest updateProduct)
    {
        var result = await _mediator.Send(updateProduct);
        return !result.IsSuccess ? BadRequest(result.Error) : Ok(result.Message);
    }

}
