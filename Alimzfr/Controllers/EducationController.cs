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
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpGet]
        public async Task<IEnumerable<TrainingCourseDto>> GetTrainingCourses()
        {
            var educations = await _educationService.GetTrainingCourse();
            return educations;
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPost]
        public async Task<int> CreateTrainingCourse([FromBody]TrainingCourseDto trainingCourse)
        {
            var trainingCourseId = await _educationService.CreateTrainingCourse(trainingCourse);
            return trainingCourseId;
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPost]
        public async Task<int> UpdateTrainingCourse([FromBody]TrainingCourseDto trainingCourse)
        {
            var trainingCourseId = await _educationService.UpdateTrainingCourse(trainingCourse);
            return trainingCourseId;
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPost]
        public async Task<bool> DeleteTrainingCourses([FromBody]int[] Ids)
        {
            var isDeleteTrainingCourses = await _educationService.DeleteTrainingCourses(Ids);
            return isDeleteTrainingCourses;
        }

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpGet]
        public async Task<IEnumerable<CollegeEducationDto>> GetCollegeEducations()
        {
            var collegeEducations = await _educationService.GetCollegeEducations();
            return collegeEducations;
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPost]
        public async Task<int> CreateCollegeEducation([FromBody]CollegeEducationDto collegeEducation)
        {
            var collegeEducationId = await _educationService.CreateCollegeEducation(collegeEducation);
            return collegeEducationId;
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPost]
        public async Task<int> UpdateCollegeEducation([FromBody]CollegeEducationDto collegeEducation)
        {
            var collegeEducationId = await _educationService.UpdateCollegeEducation(collegeEducation);
            return collegeEducationId;
        }

        [Authorize(Policy = CustomRoles.Admin)]
        [HttpPost]
        public async Task<bool> DeleteCollegeEducations([FromBody]int[] Ids)
        {
            var isDeleteCollegeEducations = await _educationService.DeleteCollegeEducations(Ids);
            return isDeleteCollegeEducations;
        }
    }
}