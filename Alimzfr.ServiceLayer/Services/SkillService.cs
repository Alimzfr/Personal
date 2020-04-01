using Alimzfr.DataLayer.Data;
using Alimzfr.DomainLayer.Entities;
using Alimzfr.ModelLayer.Models;
using Alimzfr.ServiceLayer.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alimzfr.ServiceLayer.Services
{
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
    }
}
