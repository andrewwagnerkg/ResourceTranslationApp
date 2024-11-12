using Application.Common.Mappings;
using AutoMapper;
using Core.Entities;

namespace Application.Features.Locales.Queries
{
    public class LocaleDto : IMapWith<Locale>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Locale, LocaleDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Code, opt => opt.MapFrom(x => x.Code))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

        }
    }
}
