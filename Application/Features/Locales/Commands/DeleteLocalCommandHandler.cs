using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Locales.Commands;

public class DeleteLocalCommandHandler : IRequestHandler<DeleteLocaleCommand, Unit>
{
    private readonly IApplicationDBContext _dbContext;
    public DeleteLocalCommandHandler(IApplicationDBContext applicationDbContext)
        => _dbContext = applicationDbContext;
    
    public async Task<Unit> Handle(DeleteLocaleCommand request, CancellationToken cancellationToken)
    {
            var locale = await _dbContext.Locales.FirstOrDefaultAsync(x=>x.Id == request.Id);
            if(locale != null)
                _dbContext.Locales.Remove(locale);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return await Unit.Task;
    }
}