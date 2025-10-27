using AutoMapper;
using DataAccess.Model;
using Microsoft.VisualBasic;
using Repository.Interface;
using Repository.Repositories;
using Services.DTO;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TeacherService : ITeacherService
    {
        IStudentRepo _studentRepo;
        ITeacherRepo _teacherRepo;
        ICourseRepo _courseRepo;
        IMapper _mapper;
        public TeacherService(IStudentRepo studentRepo, ITeacherRepo teacherRepo, ICourseRepo courseRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _teacherRepo = teacherRepo;
            _courseRepo = courseRepo;
            _mapper = mapper;
        }
       
        public Task<IEnumerable<CourseDTO>> GetCoursesByTeacherId(int teacherId)
        {
            throw new NotImplementedException();
        }

        public async Task<TeacherDTO> GetTeacher(int id)
        {
            var teacher = await _teacherRepo.Get(id);
            return _mapper.Map<TeacherDTO>(teacher);
        }
        public async Task<IEnumerable<TeacherDTO>> GetTeachers()
        {
            var teachers = await _teacherRepo.GetList();
            return _mapper.Map<IEnumerable<TeacherDTO>>(teachers);
        }
        public async Task AddTeacher(CreateTeacherDTO teacher)
        {
            var tea = _mapper.Map<Teacher>(teacher);
            await _teacherRepo.Insert(tea);
        }
        public async Task UpdateTeacher(UpdateTeacherDTO teacher)
        {
            var teach = await _teacherRepo.Get(teacher.ID);

            if (teach != null)
            {
                teach.IdentityNumber = teacher.IdentityNumber;
                teach.MobileNumber = teacher.MobileNumber;
                teach.FirstName = teacher.FirstName;
                teach.LastName = teacher.LastName;
                teach.Age = teacher.Age;
                await _teacherRepo.Update(teach);
            }
        }
        public async Task DeleteTeacher(int id)
        {
            await _teacherRepo.Delete(id);
        }
    }
}
