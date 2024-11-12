using Application.Features.Locales.Commands;
using Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Locales.Validators
{
    public class CreateValidator : AbstractValidator<CreateLocaleCommand>
    {
        private readonly IApplicationDBContext _dbContext;
        public CreateValidator(IApplicationDBContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Code).NotEmpty().WithMessage("Code mustn`t be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name mustn`t be empty");
            RuleFor(x => x).MustAsync(UniqueCode).WithMessage("Code should be unique");
            RuleFor(x => x).MustAsync(UniqueName).WithMessage("Name should be unique"); ;
        }

        private async Task<bool> UniqueCode(CreateLocaleCommand command, CancellationToken token)
            => !await _dbContext.Locales.AnyAsync(x => x.Code.ToUpper() == command.Code.ToUpper());

        private async Task<bool> UniqueName(CreateLocaleCommand command, CancellationToken token)
            => !await _dbContext.Locales.AnyAsync(x => x.Name.ToUpper() == command.Name.ToUpper());

    }
}
