using Application.Features.Translations.Dtos;
using MediatR;

namespace Application.Features.Translations.Commands
{
    public class UpdateTranslationCommand : IRequest<TranslationDto>
    {
        public long LanguageId { get; set; }
        public long ResourceId { get; set; }
        public string TransalationText { get; set; }
        public long  TranslationId { get; set; }
    }
}
