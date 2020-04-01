using Alimzfr.ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alimzfr.ServiceLayer.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuItemDto>> GetMenuItems();
    }
}
