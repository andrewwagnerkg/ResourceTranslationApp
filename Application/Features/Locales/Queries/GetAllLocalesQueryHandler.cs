using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Locales.Queries
{
    public class GetAllLocalesQueryHandler : IRequestHandler<GetAllLocalesQuery, IEnumerable<LocaleDto>>
    {
        private readonly IApplicationDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllLocalesQueryHandler(IApplicationDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocaleDto>> Handle(GetAllLocalesQuery request, CancellationToken cancellationToken)
            => await _dbContext.Locales
            .AsNoTracking()
            .ProjectTo<LocaleDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
    }
}
