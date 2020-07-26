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
    public interface ISkillService
    {
        Task<IEnumerable<SkillDto>> GetSkills();
        Task<int> CreateSkill(SkillDto skill);
        Task<int> UpdateSkill(SkillDto skill);
        Task<bool> DeleteSkills(int[] Ids);
    }

    public class SkillService : ISkillService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public SkillService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SkillDto>> GetSkills()
        {
            var skills = await _context.Skills.Include(x => x.Category).AsNoTracking().ToListAsync();
            var data = _mapper.Map<List<Skill>, List<SkillDto>>(skills);
            return data;
        }

        public async Task<int> CreateSkill(SkillDto skill)
        {
            try
            {
                var newSkill = _mapper.Map<SkillDto, Skill>(skill);
                _context.Skills.Add(newSkill);
                await _context.SaveChangesAsync();
                return newSkill.Id;
            }
            catch (Exception)
            {
                throw new Exception("error occurred during create skill");
            }
        }

        public async Task<int> UpdateSkill(SkillDto skill)
        {
            try
            {
                var oldSkill = await _context.Skills.Include(x => x.Category).Where(x => x.Id == skill.Id).FirstOrDefaultAsync();
                oldSkill.ModifyDate = skill.ModifyDate;


                await _context.SaveChangesAsync();
                return oldSkill.Id;
            }
            catch (Exception)
            {

                throw new Exception("error occurred during update skill");
            }
        }

        public async Task<bool> DeleteSkills(int[] Ids)
        {
            try
            {
                var skills = await _context.Skills.Where(x => Ids.Contains(x.Id)).ToListAsync();
                _context.Skills.RemoveRange(skills);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("error occurred during delete skill");
            }
        }
    }
}
