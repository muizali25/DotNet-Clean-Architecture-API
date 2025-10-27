using DataAccess;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class EnrollmentRepo : IEnrollmentRepo
    {
        CleanArchitectureContext _dbContext;
        public EnrollmentRepo(CleanArchitectureContext context)
        {
            _dbContext = context;
        }
       
     
        public async Task Insert(Enrollment enroll)
        {
            enroll.EnrollmentDate = DateTime.Now;
            await _dbContext.Enrollment.AddAsync(enroll);
            await _dbContext.SaveChangesAsync();
        }      
    }
}
