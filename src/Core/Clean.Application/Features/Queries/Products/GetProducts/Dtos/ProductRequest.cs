namespace Clean.Application.Features.Queries.Products.GetProducts.Dtos;

public record ProductRequest() : IRequest<List<ProductResponse>>;
