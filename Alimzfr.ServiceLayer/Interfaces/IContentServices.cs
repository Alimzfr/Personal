using Alimzfr.ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alimzfr.ServiceLayer.Interfaces
{
    public interface IContentServices
    {
        Task<IEnumerable<MenuItemDto>> GetMenuItems();
        Task<IEnumerable<AboutDto>> GetAbouts();
        Task<IEnumerable<SkillDto>> GetSkills();
        Task<IEnumerable<EducationDto>> GetEducations();
        Task<IEnumerable<CollegeEducationDto>> GetCollegeEducations();
        Task<IEnumerable<ExperienceDto>> GetExperiences();
    }
}
