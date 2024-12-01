using Application.Features.Translations.Commands;
using FluentValidation;

namespace Application.Features.Translations.Validators
{
    public class DeleteTranslationCommandValidator : AbstractValidator<DeleteTranslationCommand>
    {
        public DeleteTranslationCommandValidator()
        {
            
        }
    }
}
