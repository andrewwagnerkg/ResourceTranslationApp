using Application.Common.Mappings;
using AutoMapper;
using Core.Entities;

namespace Application.Features.Resources.Dtos
{
    public class ResourceDto : IMapWith<Resource>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AppKey { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Resource, ResourceDto>()
                .ForMember(x => x.Id, src => src.MapFrom(dst => dst.Id))
                .ForMember(x => x.Name, src => src.MapFrom(dst => dst.DefaultValue))
                .ForMember(x => x.AppKey, src => src.MapFrom(dst => dst.AppKey));
        }
    }
}
