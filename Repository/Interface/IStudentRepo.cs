using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
namespace Repository.Interface
{
    public interface IStudentRepo
    {
         Task Insert(Student student);
         Task Update(Student student);
        Task<Student> GetById(
  int id );
        Task<IEnumerable<Student>> GetStudentsAsync(
  int? studentId = null,
  int? courseId = null,
  int? teacherId = null);
         Task Delete(int id);
    }
}
