using MediatR;

namespace Clean.Application.Features.Abstracts.Model;

public interface IRequestModel:IRequest<IResponseModel>
{
}
