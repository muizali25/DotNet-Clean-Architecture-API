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
    public class TeacherRepo : ITeacherRepo
    {
        CleanArchitectureContext _dbContext;
        public TeacherRepo(CleanArchitectureContext context)
        {
            _dbContext = context;
        }
        public async Task Delete(int id)
        {
            var t = await _dbContext.Teacher.FindAsync(id);

            if (t != null)
            {
                _dbContext.Teacher.Remove(t);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Teacher?> Get(int id)
        { 
            return await _dbContext.Teacher.FindAsync(id);
        }

        public async Task<IEnumerable<Teacher>> GetList()
        {
            return await _dbContext.Teacher.ToListAsync();
        }
        public async Task  Insert(Teacher teacher)
        {
           await _dbContext.Teacher.AddAsync(teacher);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(Teacher teacher)
        {
          //  _dbContext.Entry(student).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
