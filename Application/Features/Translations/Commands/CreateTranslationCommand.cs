using MediatR;

namespace Application.Features.Translations.Commands
{
    public class CreateTranslationCommand : IRequest<Guid>
    {
        public long LanguageId { get; set; }
        public long ResourceId { get; set; }
        public string TranslationText { get; set; }
    }
}
