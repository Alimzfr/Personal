using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alimzfr.ModelLayer.AuthModels;
using Alimzfr.ModelLayer.Models;
using Alimzfr.ServiceLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alimzfr.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<SkillDto>> GetSkills()
        {
            var skills = await _skillService.GetSkills();
            return skills;
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPost]
        public async Task<bool> CreateSkill([FromBody]CollegeEducationDto collegeEducation)
        {

            return false;
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPost]
        public async Task<bool> UpdateSkill([FromBody]int Id)
        {
            return false;
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPost]
        public async Task<bool> DeleteSkills([FromBody]int[] Ids)
        {
            return false;
        }
    }
}