using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alimzfr.DomainLayer.Entities;
using Alimzfr.ModelLayer.AuthModels;
using Alimzfr.ModelLayer.Models;
using Alimzfr.ServiceLayer.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alimzfr.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _mapper = mapper;
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IEnumerable<AboutDto>> GetAbouts()
        {
            var abouts = await _aboutService.GetAbouts();
            return abouts;
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPost]
        public async Task<int> UpdateAbout([FromBody]AboutDto about)
        {
            return await _aboutService.UpdateAbout(about);
        }
    }
}