using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Model;
using Services.DTO;

namespace Services.Mapper
{
   public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<CreateStudentDTO, Student>();
            CreateMap<UpdateStudentDTO, Student>();
            CreateMap<Teacher, TeacherDTO>();
            CreateMap<CreateTeacherDTO, Teacher>();
            CreateMap<UpdateTeacherDTO, Teacher>();
            CreateMap<Course, CourseDTO>();
        }
    }
}
