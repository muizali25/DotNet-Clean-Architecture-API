using DataAccess.Model;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ITeacherService
    {
        Task AddTeacher(CreateTeacherDTO student);
        Task UpdateTeacher(UpdateTeacherDTO student);
        Task DeleteTeacher(int id);
        Task<TeacherDTO> GetTeacher(int id);
        Task<IEnumerable<TeacherDTO>> GetTeachers();       
    }
}
