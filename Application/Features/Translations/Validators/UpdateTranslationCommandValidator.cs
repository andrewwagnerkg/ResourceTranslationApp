using Application.Features.Translations.Commands;
using FluentValidation;

namespace Application.Features.Translations.Validators
{
    public class UpdateTranslationCommandValidator : AbstractValidator<UpdateTranslationCommand>
    {
        public UpdateTranslationCommandValidator() { }
    }
}
