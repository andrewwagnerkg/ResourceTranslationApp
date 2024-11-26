using Application.Features.Resources.Commands;
using Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Resources.Validators
{
    public class CreateResourceValidator : AbstractValidator<CreateResourceCommand>
    {
        private readonly IApplicationDBContext _dbContext;
        public CreateResourceValidator(IApplicationDBContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Key).NotEmpty().WithMessage("Code mustn`t be empty");
            RuleFor(x => x.DefaultName).NotEmpty().WithMessage("Name mustn`t be empty");
            RuleFor(x => x).MustAsync(UniqueCode).WithMessage("Key should be unique");
            RuleFor(x => x).MustAsync(UniqueName).WithMessage("Name should be unique"); ;
        }

        private async Task<bool> UniqueCode(CreateResourceCommand command, CancellationToken token)
            => !await _dbContext.Resources.AnyAsync(x => x.AppKey.ToUpper() == command.Key.ToUpper());

        private async Task<bool> UniqueName(CreateResourceCommand command, CancellationToken token)
            => !await _dbContext.Resources.AnyAsync(x => x.DefaultValue.ToUpper() == command.DefaultName.ToUpper());
    }
}
