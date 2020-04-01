using Alimzfr.DataLayer.Data;
using Alimzfr.DomainLayer.Entities;
using Alimzfr.ModelLayer.Models;
using Alimzfr.ServiceLayer.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alimzfr.ServiceLayer.Services
{
    public class EducationService : IEducationService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public EducationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CollegeEducationDto>> GetCollegeEducations()
        {
            var collegeEducations = await _context.CollegeEducations.AsNoTracking().ToListAsync();
            var data = _mapper.Map<List<CollegeEducation>, List<CollegeEducationDto>>(collegeEducations);
            return data;
        }

        public async Task<IEnumerable<TrainingCourseDto>> GetTrainingCourse()
        {
            var educations = await _context.TrainingCourses.AsNoTracking().ToListAsync();
            var data = _mapper.Map<List<TrainingCourse>, List<TrainingCourseDto>>(educations);
            return data;
        }
    }
}
