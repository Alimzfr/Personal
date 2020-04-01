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
    public class MenuService : IMenuService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public MenuService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MenuItemDto>> GetMenuItems()
        {
            var menuItems = await _context.MenuItems.OrderBy(x => x.SequenceNumber).AsNoTracking().ToListAsync();
            var data = _mapper.Map<List<MenuItem>, List<MenuItemDto>>(menuItems);
            return data;
        }
    }
}
