using Application.Features.Translations.Commands;
using Application.Interfaces;
using Core.Entities;
using MediatR;

namespace Application.Features.Translations.Handlers
{
    public class CreateTranslationCommandHandler : IRequestHandler<CreateTranslationCommand, Guid>
    {
        private readonly IApplicationDBContext _dbContext;
        
        public CreateTranslationCommandHandler(IApplicationDBContext context)
            => _dbContext = context;

        public async Task<Guid> Handle(CreateTranslationCommand request, CancellationToken cancellationToken)
        {
            var translation = new Translation
            {
                TranslatedValue = request.TranslationText,
                ResourceId = request.ResourceId,
                LocaleId = request.LanguageId
            };
            await _dbContext.Translations.AddAsync(translation);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return translation.Id;
        }
    }
}
