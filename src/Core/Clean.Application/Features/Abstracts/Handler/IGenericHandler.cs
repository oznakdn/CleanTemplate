using MediatR;

namespace Clean.Application.Features.Abstracts.Handler;

public interface IGenericHandler<Request, Response> : IRequestHandler<Request, Response>
where Request : IRequest<Response>
where Response : class, new()
{

}
