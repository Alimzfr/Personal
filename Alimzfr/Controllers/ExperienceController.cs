using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alimzfr.ModelLayer.AuthModels;
using Alimzfr.ModelLayer.Models;
using Alimzfr.ServiceLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alimzfr.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;
        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpGet]
        public async Task<IEnumerable<ExperienceDto>> GetExperiences()
        {
            var experiences = await _experienceService.GetExperiences();
            return experiences;
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPost]
        public async Task<bool> CreateExperience([FromBody]ExperienceDto experience)
        {
            return false;
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPost]
        public async Task<bool> UpdateExperience([FromBody]int Id)
        {
            return false;
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPost]
        public async Task<bool> DeleteExperiences([FromBody]int[] Ids)
        {
            return false;
        }
    }
}