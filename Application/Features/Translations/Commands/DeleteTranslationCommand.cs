using MediatR;

namespace Application.Features.Translations.Commands
{
    public class DeleteTranslationCommand : IRequest<Unit>
    {
        public long TrnslationId { get; set; }
    }
}
