using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alimzfr.ModelLayer.Models;
using Alimzfr.ServiceLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Alimzfr.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IEnumerable<MenuItemDto>> GetMenuItems()
        {
            var menuItems = await _menuService.GetMenuItems();
            return menuItems;
        }
    }
}