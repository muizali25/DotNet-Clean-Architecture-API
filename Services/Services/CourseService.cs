using Repository.Interface;
using Services.DTO;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using AutoMapper;

namespace Services.Services
{
    public class CourseService : ICourseService
    {
        IEnrollmentRepo _enrollRepo;
        ICourseRepo _courseRepo;
        IMapper _mapper;
        public CourseService(IEnrollmentRepo enrollRepo, ICourseRepo courseRepo,
              IMapper mapper)
        {
            _enrollRepo = enrollRepo;
            _courseRepo = courseRepo;
            _mapper = mapper;
        }

        public async Task AddCourse(CreateCourseDTO course)
        {
           await _courseRepo.Insert(new Course
            {
                Description = course.Description,
                Title = course.Title,
            });            
        }

        public Task DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public async Task EnrollCourseWithStudent(int courseId, int studentId)
        {
            // check if exist.
           await _enrollRepo.Insert(new Enrollment
            {
                CourseID = courseId,
                StudentID = studentId
            });
        }
        public async Task EnrollCourseWithTeacher(int courseId, int teacherId)
        {
            var course =  await _courseRepo.GetById(courseId);

            if(course != null)
            {
                course.TeacherID = teacherId;   
                await _courseRepo.Update(course);
            }
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByStudentId(int studentId)
        {
            var course = await _courseRepo.GetCourseByStudentId(studentId);
            return _mapper.Map<IEnumerable<CourseDTO>>(course);
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByTeacherId(int teacherId)
        {
            var course = await _courseRepo.GetList(teacherId: teacherId);
            return _mapper.Map<IEnumerable<CourseDTO>>(course);
        }

        public async Task UpdateCourse(UpdateCourseDTO c)
        {
            var course = await _courseRepo.GetById(c.ID);

            if(course != null)
            {
                course.Title = c.Title;
                course.Description = c.Description;
               await _courseRepo.Update(course);
            }
        }
    }
}
