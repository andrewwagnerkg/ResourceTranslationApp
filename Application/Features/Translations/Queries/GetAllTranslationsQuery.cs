using Application.Features.Translations.Dtos;
using MediatR;

namespace Application.Features.Translations.Queries
{
    public class GetAllTranslationsQuery : IRequest<IEnumerable<TranslationDto>>
    {
        public long? ResourceId { get; set; }
        public long? LocaleId { get; set; }
    }
}
