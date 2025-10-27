using AutoMapper;
using DataAccess.Model;
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
    public class StudentService : IStudentService
    {
        IStudentRepo _studentRepo;
        IMapper _mapper;
        public StudentService(IStudentRepo studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;           
            _mapper = mapper;
        }
        public async Task AddStudent(CreateStudentDTO student)
        {
            var std = _mapper.Map<Student>(student);
            await _studentRepo.Insert(std);
        }
        public async Task UpdateStudent(UpdateStudentDTO std)
        {
            var student = (await _studentRepo.GetStudentsAsync(std.ID)).FirstOrDefault();

            if (student != null)
            {
                student.IdentityNumber = std.IdentityNumber;
                student.MobileNumber = std.MobileNumber;
                student.FirstName = std.FirstName;
                student.LastName = std.LastName;
                student.Age = std.Age;

                // var std = _mapper.Map<Student>(student);
                await _studentRepo.Update(student);
            }          
        }
      
        public async Task DeleteStudent(int id)
        {
            await _studentRepo.Delete(id);
        }        

       
        public Task DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentDTO> GetStudent(int id)
        {
            var student = (await _studentRepo.GetStudentsAsync(studentId:id)).FirstOrDefault();
            var studentDto = _mapper.Map<StudentDTO>(student);
            return studentDto;
        }
        public async Task<IEnumerable<StudentDTO>> GetStudents()
        {
            var students = await _studentRepo.GetStudentsAsync();
            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }
    }
}
