using MediatR;

namespace Clean.Application.Features.Product.Dtos;

public record ProductRequest():IRequest<ProductResponse>;
