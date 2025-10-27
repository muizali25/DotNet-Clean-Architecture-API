using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace Repository.Interface
{
   public interface ICourseRepo
    {
         Task Insert(Course student);
         Task Update(Course student);
         Task<Course?> GetById(int id);
        Task<IEnumerable<Course>> GetList(int? studentId = null,
  int? courseId = null,
  int? teacherId = null);
         Task Delete(int id);
        Task<IEnumerable<Course>> GetCourseByStudentId(int studentId);
    }
}
