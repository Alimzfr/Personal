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
        Task<int> CreateExperience(ExperienceDto experience);
        Task<int> UpdateExperience(ExperienceDto experience);
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

        public async Task<int> CreateExperience(ExperienceDto experience)
        {
            try
            {
                var newExperience = _mapper.Map<ExperienceDto, Experience>(experience);
                _context.Experiences.Add(newExperience);
                await _context.SaveChangesAsync();
                return newExperience.Id;

            }
            catch (Exception)
            {
                throw new Exception("error occurred during create experience");
            }
        }

        public async Task<int> UpdateExperience(ExperienceDto experience)
        {
            try
            {
                var oldExperience = await _context.Experiences.Where(x => x.Id == experience.Id).FirstOrDefaultAsync();
                oldExperience.ModifyDate = DateTime.Now;

                oldExperience.EnglishCompanyName = experience.EnglishCompanyName;
                oldExperience.EnglishDescription = experience.EnglishDescription;
                oldExperience.EnglishJobTitle = experience.EnglishJobTitle;

                oldExperience.PersianCompanyName = experience.PersianCompanyName;
                oldExperience.PersianDescription = experience.PersianDescription;
                oldExperience.PersianJobTitle = experience.PersianJobTitle;

                oldExperience.FromDate = experience.GregorianFromDate;
                oldExperience.ToDate = experience.GregorianToDate;
                oldExperience.SequenceNumber = experience.SequenceNumber;

                await _context.SaveChangesAsync();
                return oldExperience.Id;

            }
            catch (Exception)
            {
                throw new Exception("error occurred during update experience");
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
