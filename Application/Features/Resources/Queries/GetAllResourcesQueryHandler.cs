using Application.Features.Resources.Dtos;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Resources.Queries
{
    public class GetAllResourcesQueryHandler : IRequestHandler<GetAllResourcesQuery, IEnumerable<ResourceDto>>
    {
        private readonly IApplicationDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllResourcesQueryHandler(IApplicationDBContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<IEnumerable<ResourceDto>> Handle(GetAllResourcesQuery request, CancellationToken cancellationToken)
            => await _dbContext.Resources.ProjectTo<ResourceDto>(_mapper.ConfigurationProvider).ToListAsync();
        
    }
}
