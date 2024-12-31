using Application.Features.Translations.Dtos;
using Application.Features.Translations.Queries;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Translations.Handlers
{
    public class GetAllTranslationsQueryHandler : IRequestHandler<GetAllTranslationsQuery, IEnumerable<TranslationDto>>
    {
        private readonly IApplicationDBContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllTranslationsQueryHandler(IApplicationDBContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<IEnumerable<TranslationDto>> Handle(GetAllTranslationsQuery request,
            CancellationToken cancellationToken)
        {
            var query = _dbContext.Translations
                .Include(x=>x.Locale)
                .Include(x=>x.Resource)
                .AsNoTracking()
                .AsQueryable();
            if(request.ResourceId.HasValue)
                query = query.Where(x=>x.ResourceId == request.ResourceId);
            if(request.LocaleId.HasValue)
                query = query.Where(x=>x.LocaleId == request.LocaleId);
            return await query.ProjectTo<TranslationDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
