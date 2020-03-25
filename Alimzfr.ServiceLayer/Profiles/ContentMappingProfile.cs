using Alimzfr.DomainLayer.Entities;
using Alimzfr.ModelLayer.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alimzfr.ServiceLayer.Profiles
{
    public class ContentMappingProfile : Profile
    {
        public ContentMappingProfile()
        {
            CreateMap<About, AboutDto>();
            CreateMap<Skill, SkillDto>();
            CreateMap<Experience, ExperienceDto>()
                .ForMember(dest => dest.GregorianFromDate,
                opt => opt.MapFrom(src => src.FromDate))
                .ForMember(dest=>dest.GregorianToDate,
                opt=>opt.MapFrom(src=>src.ToDate));
            CreateMap<Education, EducationDto>()
                .ForMember(dest=>dest.GregorianFromDate,
                opt=>opt.MapFrom(src=>src.FromDate))
                .ForMember(dest=>dest.GregorianToDate,
                opt=>opt.MapFrom(src=>src.ToDate));
            CreateMap<CollegeEducation, CollegeEducationDto>()
                .ForMember(dest=>dest.GregorianGraduationDate,
                opt=>opt.MapFrom(src=>src.GraduationDate));
        }
    }
}
