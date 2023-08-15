using MediatR;

namespace Clean.Application.Features.Queries.Products.GetProducts.Dtos;

public record ProductRequest() : IRequest<ProductResponse>;
