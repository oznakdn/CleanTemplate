namespace Clean.Application.Features.Abstracts.Handler;

public abstract class GenericHandler<Request, Response> : IRequestHandler<Request, Response>
where Request : IRequest<Response>
where Response : class, new()
{
    public virtual async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new Response());
    }
}
