using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
namespace Repository.Interface
{
    public interface ITeacherRepo
    {
        Task Insert(Teacher student);
        Task Update(Teacher student);
        Task<Teacher?> Get(int id);
        Task<IEnumerable<Teacher?>> GetList();
        Task Delete(int id);
    }
}
