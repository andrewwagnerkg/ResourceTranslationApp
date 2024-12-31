using Application.Features.Locales.Commands;
using Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Locales.Validators;

public class DeleteValidator:AbstractValidator<DeleteLocaleCommand>
{
    private readonly IApplicationDBContext _dbContext;
    
    public DeleteValidator(IApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
        RuleFor(x=>x.Id).GreaterThan(0).WithMessage("Id should be greater than 0");
    }
}