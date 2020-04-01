using Alimzfr.ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alimzfr.ServiceLayer.Interfaces
{
    public interface IEducationService
    {
        Task<IEnumerable<TrainingCourseDto>> GetTrainingCourse();
        Task<IEnumerable<CollegeEducationDto>> GetCollegeEducations();
    }
}
