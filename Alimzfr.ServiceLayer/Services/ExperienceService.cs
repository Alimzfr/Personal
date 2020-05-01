using Alimzfr.DataLayer.Data;
using Alimzfr.DomainLayer.Entities;
using Alimzfr.ModelLayer.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alimzfr.ServiceLayer.Services
{
    public interface IExperienceService
    {
        Task<IEnumerable<ExperienceDto>> GetExperiences();
        Task<bool> CreateExperience(ExperienceDto experience);
        Task<bool> UpdateExperience(ExperienceDto experience);
        Task<bool> DeleteExperiences(int[] Ids);
    }

    public class ExperienceService : IExperienceService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ExperienceService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExperienceDto>> GetExperiences()
        {
            var experiences = await _context.Experiences.OrderBy(x => x.SequenceNumber).AsNoTracking().ToListAsync();
            var data = _mapper.Map<List<Experience>, List<ExperienceDto>>(experiences);
            return data;
        }

        public async Task<bool> CreateExperience(ExperienceDto experience)
        {
            try
            {
                var newExperience = _mapper.Map<ExperienceDto, Experience>(experience);
                _context.Experiences.Add(newExperience);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateExperience(ExperienceDto experience)
        {
            try
            {
                var updateExperience = _mapper.Map<ExperienceDto, Experience>(experience);
                _context.Experiences.Update(updateExperience);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteExperiences(int[] Ids)
        {
            try
            {
                var experiences = await _context.Experiences.Where(x => Ids.Contains(x.Id)).ToListAsync();
                _context.Experiences.RemoveRange(experiences);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
