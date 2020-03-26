using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alimzfr.ModelLayer.Models;
using Alimzfr.ServiceLayer.Interfaces;
using Alimzfr.ServiceLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Alimzfr.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentServices _contentServices;
        private readonly ILogger<ContentController> _logger;
        public ContentController(ILogger<ContentController> logger, IContentServices contentServices)
        {
            _logger = logger;
            _contentServices = contentServices;
        }

        [HttpGet]
        public async Task<IEnumerable<MenuItemDto>> GetMenuItems()
        {
            var menuItems = await _contentServices.GetMenuItems();
            return menuItems;
        }

        [HttpGet]
        public async Task<IEnumerable<AboutDto>> GetAbouts()
        {
            var abouts = await _contentServices.GetAbouts();
            return abouts;
        }

        [HttpGet]
        public async Task<IEnumerable<SkillDto>> GetSkills()
        {
            var abouts = await _contentServices.GetSkills();
            return abouts;
        }

        [HttpGet]
        public async Task<IEnumerable<EducationDto>> GetEducations()
        {
            var educations = await _contentServices.GetEducations();
            return educations;
        }

        [HttpGet]
        public async Task<IEnumerable<CollegeEducationDto>> GetCollegeEducations()
        {
            var collegeEducations = await _contentServices.GetCollegeEducations();
            return collegeEducations;
        }

        [HttpGet]
        public async Task<IEnumerable<ExperienceDto>> GetExperiences()
        {
            var experiences = await _contentServices.GetExperiences();
            return experiences;
        }
    }
}