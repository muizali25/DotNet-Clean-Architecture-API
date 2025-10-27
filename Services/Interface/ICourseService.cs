using DataAccess.Model;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICourseService
    {
        Task AddCourse(CreateCourseDTO course);
        Task UpdateCourse(UpdateCourseDTO course);
        Task EnrollCourseWithTeacher(int courseId, int teacherId);
        Task EnrollCourseWithStudent(int courseId, int studentId);
        Task DeleteCourse(int id);
        Task<IEnumerable<CourseDTO>> GetCoursesByTeacherId(int teacherId);
        Task<IEnumerable<CourseDTO>> GetCoursesByStudentId(int studentId);
    }
}
