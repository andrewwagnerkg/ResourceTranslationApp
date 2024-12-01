using Application.Features.Translations.Commands;
using MediatR;

namespace Application.Features.Translations.Handlers
{
    public class DeleteTranslationCommandHandler : IRequestHandler<DeleteTranslationCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteTranslationCommand request, CancellationToken cancellationToken)
        {
            return await Unit.Task;
        }
    }
}
