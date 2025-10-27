using DataAccess.Model;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IStudentService
    {
        Task AddStudent(CreateStudentDTO student);
        Task UpdateStudent(UpdateStudentDTO student);
        Task DeleteStudent(int id);
        Task<StudentDTO> GetStudent(int id);
        Task<IEnumerable<StudentDTO>> GetStudents();
    }
}
