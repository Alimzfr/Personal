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
    public class AboutService : IAboutService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public AboutService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AboutDto>> GetAbouts()
        {
            var abouts = await _context.Abouts.AsNoTracking().ToListAsync();
            var data = _mapper.Map<List<About>, List<AboutDto>>(abouts);
            return data;
        }
    }
}
