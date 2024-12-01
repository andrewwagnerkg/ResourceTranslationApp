using Application.Features.Translations.Dtos;
using MediatR;

namespace Application.Features.Translations.Queries
{
    public class GetTranslationQuery : IRequest<TranslationDto>
    {
        public long ResourceId { get; set; }
    }
}
