using Application.Interfaces;
using Core.Entities;
using MediatR;

namespace Application.Features.Locales.Commands
{
    public class CreateLocaleCommandHandler : IRequestHandler<CreateLocaleCommand, long>
    {
        private readonly IApplicationDBContext _dbContext;

        public CreateLocaleCommandHandler(IApplicationDBContext context)
        {
            _dbContext = context;    
        }

        public async Task<long> Handle(CreateLocaleCommand request, CancellationToken cancellationToken)
        {
            var locale = new Locale { Code = request.Code, Name = request.Name };
            _dbContext.Locales.Add(locale);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return locale.Id;
        }
    }
}
