using Application.Features.Resources.Dtos;
using MediatR;

namespace Application.Features.Resources.Queries
{
    public class GetAllResourcesQuery : IRequest<IEnumerable<ResourceDto>>
    {
    }
}
