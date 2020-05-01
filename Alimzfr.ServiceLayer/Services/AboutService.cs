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
    public interface IAboutService
    {
        Task<IEnumerable<AboutDto>> GetAbouts();
        Task<int> UpdateAbout(AboutDto about);
    }
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
        public async Task<int> UpdateAbout(AboutDto about)
        {
            try
            {
                var oldAbout = await _context.Abouts.Where(x => x.Id == about.Id).FirstOrDefaultAsync();
                oldAbout.ModifyDate = DateTime.Now;
                if (about.PersianDescription != null) {
                    oldAbout.PersianDescription = about.PersianDescription;
                }
                if(about.EnglishDescription != null)
                {
                    oldAbout.EnglishDescription = about.EnglishDescription;
                }
                await _context.SaveChangesAsync();
                return oldAbout.Id;
            }
            catch (Exception)
            {
                throw new Exception("error occurred during update about");
            }
            
        }
    }
}
