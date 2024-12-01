using Application.Common.Mappings;
using AutoMapper;
using Core.Entities;

namespace Application.Features.Translations.Dtos
{
    public class TranslationDto : IMapWith<Translation>
    {
        public string ResourceDefaultValue { get; set; }
        public string ResourceKey { get; set; }
        public string Locale { get; set; }
        public string Translation { get; set; }
        
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Translation, TranslationDto>()
                .ForMember(x => x.Locale, dest
                    => dest.MapFrom(x => x.Locale.Name))
                .ForMember(x=>x.ResourceKey, dest
                    =>dest.MapFrom(x=>x.Resource.AppKey))
                .ForMember(x=>x.ResourceDefaultValue, dest 
                    => dest.MapFrom(x=>x.Resource.DefaultValue))
                .ForMember(x=>x.Translation, dest 
                    =>dest.MapFrom(x=>x.TranslatedValue) );
        }
    }
}
