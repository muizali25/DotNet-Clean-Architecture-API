using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace Repository.Interface
{
   public interface IEnrollmentRepo
    {
         Task Insert(Enrollment student);       
       
    }
}
