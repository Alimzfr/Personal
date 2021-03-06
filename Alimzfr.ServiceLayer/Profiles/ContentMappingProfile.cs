﻿using Alimzfr.DomainLayer.Entities;
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
            CreateMap<MenuItem, MenuItemDto>();

            CreateMap<About, AboutDto>()
            .ReverseMap();

            CreateMap<Skill, SkillDto>()
                .ForMember(dest => dest.PersianCategoryName,
                opt => opt.MapFrom(src => src.Category.PersianCategoryName))
                .ForMember(dest => dest.EnglishCategoryName,
                opt => opt.MapFrom(src => src.Category.EnglishCategoryName))
                .ForMember(dest => dest.CategoryColor,
                opt => opt.MapFrom(src => src.Category.CategoryColor))
                .ReverseMap();

            CreateMap<Experience, ExperienceDto>()
                .ForMember(dest => dest.GregorianFromDate,
                opt => opt.MapFrom(src => src.FromDate))
                .ForMember(dest => dest.GregorianToDate,
                opt => opt.MapFrom(src => src.ToDate))
                .ReverseMap();

            CreateMap<TrainingCourse, TrainingCourseDto>()
                .ForMember(dest => dest.GregorianFromDate,
                opt => opt.MapFrom(src => src.FromDate))
                .ForMember(dest => dest.GregorianToDate,
                opt => opt.MapFrom(src => src.ToDate))
                .ReverseMap();

            CreateMap<CollegeEducation, CollegeEducationDto>()
                .ForMember(dest => dest.GregorianGraduationDate,
                opt => opt.MapFrom(src => src.GraduationDate))
                .ReverseMap();

            CreateMap<UserMessage, UserMessageDto>()
                .ReverseMap()
                .ForPath(src => src.CreatDate,
                opt => opt.MapFrom(src => DateTime.Now))
                .ReverseMap();

        }
    }
}
