using AutoMapper;
using Core.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<CreateEducationDto, Education>();
            CreateMap<EducationDto, Education>().ReverseMap();
            CreateMap<EditEducationDto, Education>();

            CreateMap<RegisterDto, User>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.Email));
        }
    }
}
