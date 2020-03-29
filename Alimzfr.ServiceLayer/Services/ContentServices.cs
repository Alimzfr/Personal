using Alimzfr.DataLayer.Data;
using Alimzfr.DomainLayer.Entities;
using Alimzfr.ModelLayer.Models;
using Alimzfr.ServiceLayer.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alimzfr.ServiceLayer.Services
{
    public class ContentServices: IContentServices
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ContentServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuItemDto>> GetMenuItems()
        {
            var menuItems = await _context.MenuItems.OrderBy(x=>x.SequenceNumber).AsNoTracking().ToListAsync();
            var data = _mapper.Map<List<MenuItem>, List<MenuItemDto>>(menuItems);
            return data;
        }

        public async Task<IEnumerable<AboutDto>> GetAbouts()
        {
            var abouts = await _context.Abouts.AsNoTracking().ToListAsync();
            var data = _mapper.Map<List<About>,List<AboutDto>>(abouts);
            return data;
        }

        public async Task<IEnumerable<SkillDto>> GetSkills()
        {
            var skills = await _context.Skills.Include(x=>x.Category).AsNoTracking().ToListAsync();
            var data = _mapper.Map<List<Skill>, List<SkillDto>>(skills);
            return data;
        }

        public async Task<IEnumerable<EducationDto>> GetEducations()
        {
            var educations = await _context.Educations.AsNoTracking().ToListAsync();
            var data = _mapper.Map<List<Education>, List<EducationDto>>(educations);
            return data;
        }

        public async Task<IEnumerable<CollegeEducationDto>> GetCollegeEducations()
        {
            var collegeEducations = await _context.CollegeEducations.AsNoTracking().ToListAsync();
            var data = _mapper.Map<List<CollegeEducation>, List<CollegeEducationDto>>(collegeEducations);
            return data;
        }

        public async Task<IEnumerable<ExperienceDto>> GetExperiences()
        {
            var experiences = await _context.Experiences.AsNoTracking().ToListAsync();
            var data = _mapper.Map<List<Experience>, List<ExperienceDto>>(experiences);
            return data;
        }
    }
}
