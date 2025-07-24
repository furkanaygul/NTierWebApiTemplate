using AutoMapper;
using BaseProjectTemplate._1.EntityLayer.Concreate;
using BaseProjectTemplate._4.ServiceLayer.DTOs;

namespace BaseProjectTemplate._4.ServiceLayer.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<DemoClass, DemoDto>()
                .ReverseMap();
        }
    }
}
