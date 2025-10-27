using DataAccess.Model;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    interface IStudentService
    {
        Task<StudentDTO> Get(int id);
        Task<IEnumerable<StudentDTO>> GetList();
        
    }
}
