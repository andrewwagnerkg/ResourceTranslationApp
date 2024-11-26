using Application.Interfaces;
using Core.Entities;
using MediatR;

namespace Application.Features.Resources.Commands
{
    public class CreateResourceCommandHandler : IRequestHandler<CreateResourceCommand, long>
    {
        private readonly IApplicationDBContext _dbContext;

        public CreateResourceCommandHandler(IApplicationDBContext dBContext)
            => _dbContext = dBContext;

        public async Task<long> Handle(CreateResourceCommand request, CancellationToken cancellationToken)
        {
            var resource = new Resource { AppKey = request.Key, DefaultValue = request.DefaultName };
            await _dbContext.Resources.AddAsync(resource);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return resource.Id;
        }
    }
}
