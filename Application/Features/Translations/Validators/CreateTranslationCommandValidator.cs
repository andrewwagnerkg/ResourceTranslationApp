using Application.Features.Translations.Commands;
using Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Translations.Validators
{
    public class CreateTranslationCommandValidator : AbstractValidator<CreateTranslationCommand>
    {
        private readonly IApplicationDBContext _dbContext;
        public CreateTranslationCommandValidator(IApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(x=>x.TranslationText).NotEmpty().WithMessage("Translation text cannot be empty");
            RuleFor(x=>x.ResourceId).GreaterThan(0).WithMessage("Resource id must be greater than 0")
                .MustAsync(IsResourceExist).WithMessage("Resource must exist");
            RuleFor(x=>x.LanguageId).GreaterThan(0).WithMessage("Resource id cannot be empty")
                .MustAsync(IsLocaleExist).WithMessage("Locale must exist");
        }

        private async Task<bool> IsLocaleExist(long localeId, CancellationToken cancellationToken = default)
            => await _dbContext.Locales.AnyAsync(x=>x.Id == localeId, cancellationToken);
        
        private async Task<bool> IsResourceExist(long resourceId, CancellationToken cancelationToken = default)
            => await _dbContext.Resources.AnyAsync(x=>x.Id == resourceId, cancelationToken);
        
    }
}
