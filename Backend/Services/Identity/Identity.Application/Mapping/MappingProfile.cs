using AutoMapper;
using Identity.Application.Models;
using Identity.Domain.Entities;

namespace Identity.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginModel, User>().ReverseMap();
            CreateMap<RegisterModel, User>().ReverseMap();
        }
    }
}
