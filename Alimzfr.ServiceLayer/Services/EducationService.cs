using Alimzfr.DataLayer.Data;
using Alimzfr.DomainLayer.Entities;
using Alimzfr.ModelLayer.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alimzfr.ServiceLayer.Services
{
    public interface IEducationService
    {
        Task<IEnumerable<TrainingCourseDto>> GetTrainingCourse();
        Task<int> CreateTrainingCourse(TrainingCourseDto trainingCourse);
        Task<int> UpdateTrainingCourse(TrainingCourseDto trainingCourse);
        Task<bool> DeleteTrainingCourses(int[] Ids);

        Task<IEnumerable<CollegeEducationDto>> GetCollegeEducations();
        Task<int> CreateCollegeEducation(CollegeEducationDto collegeEducation);
        Task<int> UpdateCollegeEducation(CollegeEducationDto collegeEducation);
        Task<bool> DeleteCollegeEducations(int[] Ids);
    }

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

        public async Task<int> CreateCollegeEducation(CollegeEducationDto collegeEducation)
        {
            try
            {
                var newCollegeEducation = _mapper.Map<CollegeEducationDto, CollegeEducation>(collegeEducation);
                _context.CollegeEducations.Add(newCollegeEducation);
                await _context.SaveChangesAsync();
                return newCollegeEducation.Id;
            }
            catch (Exception)
            {
                throw new Exception("error occurred during create college education");
            }
        }

        public async Task<int> UpdateCollegeEducation(CollegeEducationDto collegeEducation)
        {
            try
            {
                var oldcollege = await _context.CollegeEducations.Where(x => x.Id == collegeEducation.Id).FirstOrDefaultAsync();
                oldcollege.ModifyDate = DateTime.Now;
                oldcollege.GraduationDate = collegeEducation.GregorianGraduationDate;

                oldcollege.EnglishAcademicField = collegeEducation.EnglishAcademicField;
                oldcollege.EnglishDegreeLevel = collegeEducation.EnglishDegreeLevel;
                oldcollege.EnglishDescription = collegeEducation.EnglishDescription;
                oldcollege.EnglishUniversity = collegeEducation.EnglishUniversity;

                oldcollege.PersianAcademicField = collegeEducation.PersianAcademicField;
                oldcollege.PersianDegreeLevel = collegeEducation.PersianDegreeLevel;
                oldcollege.PersianDescription = collegeEducation.PersianDescription;
                oldcollege.PersianUniversity = collegeEducation.PersianUniversity;

                await _context.SaveChangesAsync();
                return oldcollege.Id;
            }
            catch (Exception)
            {

                throw new Exception("error occurred during update college education");
            }
        }

        public async Task<bool> DeleteCollegeEducations(int[] Ids)
        {
            try
            {
                var colleges = await _context.CollegeEducations.Where(x => Ids.Contains(x.Id)).ToListAsync();
                _context.CollegeEducations.RemoveRange(colleges);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<TrainingCourseDto>> GetTrainingCourse()
        {
            var educations = await _context.TrainingCourses.AsNoTracking().ToListAsync();
            var data = _mapper.Map<List<TrainingCourse>, List<TrainingCourseDto>>(educations);
            return data;
        }

        public async Task<int> CreateTrainingCourse(TrainingCourseDto trainingCourse)
        {
            try
            {
                var newTrainingCourse = _mapper.Map<TrainingCourseDto, TrainingCourse>(trainingCourse);
                _context.TrainingCourses.Add(newTrainingCourse);
                await _context.SaveChangesAsync();
                return newTrainingCourse.Id;
            }
            catch (Exception)
            {
                throw new Exception("error occurred during create college education");
            }
        }

        public async Task<int> UpdateTrainingCourse(TrainingCourseDto trainingCourse)
        {
            try
            {
                var oldtrainingCourse = await _context.TrainingCourses.Where(x => x.Id == trainingCourse.Id).FirstOrDefaultAsync();
                oldtrainingCourse.ModifyDate = DateTime.Now;
                oldtrainingCourse.Duration = trainingCourse.Duration;
                oldtrainingCourse.FromDate = trainingCourse.FromDate;
                oldtrainingCourse.ToDate = trainingCourse.ToDate;

                oldtrainingCourse.EnglishCourseName = trainingCourse.EnglishCourseName;
                oldtrainingCourse.EnglishDescription = trainingCourse.EnglishDescription;
                oldtrainingCourse.EnglishEducationalInstitute = trainingCourse.EnglishEducationalInstitute;

                oldtrainingCourse.PersianCourseName = trainingCourse.PersianCourseName;
                oldtrainingCourse.PersianDescription = trainingCourse.PersianDescription;
                oldtrainingCourse.PersianEducationalInstitute = trainingCourse.PersianEducationalInstitute;

                await _context.SaveChangesAsync();
                return oldtrainingCourse.Id;
            }
            catch (Exception)
            {
                throw new Exception("error occurred during update training course");
            }
        }

        public async Task<bool> DeleteTrainingCourses(int[] Ids)
        {
            try
            {
                var trainingCourses = await _context.TrainingCourses.Where(x => Ids.Contains(x.Id)).ToListAsync();
                _context.TrainingCourses.RemoveRange(trainingCourses);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
