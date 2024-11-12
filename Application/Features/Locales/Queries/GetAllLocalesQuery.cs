using MediatR;

namespace Application.Features.Locales.Queries
{
    public class GetAllLocalesQuery : IRequest<IEnumerable<LocaleDto>>
    {
    }
}
