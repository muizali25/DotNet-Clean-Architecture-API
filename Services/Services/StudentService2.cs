using AutoMapper;
using DataAccess.Model;
using Microsoft.VisualBasic;
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
    class StudentService : IStudentService
    {
        StudentRepo _studentRepo;
        IMapper _mapper;
        public StudentService(StudentRepo studentRepo, IMapper mapper) {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }     

        

        public async Task<StudentDTO> Get(int id)
        {
           var student =  _studentRepo.Get(id);
           return _mapper.Map<StudentDTO>(student);
        }

        public async Task<IEnumerable<StudentDTO>> GetList()
        {
            var students = _studentRepo.GetList();
            return _mapper.Map<List<StudentDTO>>(students);
        }

      
    }
}
