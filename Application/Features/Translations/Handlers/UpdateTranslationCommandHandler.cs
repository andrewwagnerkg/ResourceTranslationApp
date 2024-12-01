using Application.Features.Translations.Commands;
using Application.Features.Translations.Dtos;
using MediatR;

namespace Application.Features.Translations.Handlers
{
    public class UpdateTranslationCommandHandler : IRequestHandler<UpdateTranslationCommand, TranslationDto>
    {
        public async Task<TranslationDto> Handle(UpdateTranslationCommand request, CancellationToken cancellationToken)
        {
            return new TranslationDto();
        }
    }
}
