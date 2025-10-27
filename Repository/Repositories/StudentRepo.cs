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
    public class StudentRepo : IStudentRepo
    {
        CleanArchitectureContext _dbContext;
        public StudentRepo(CleanArchitectureContext context)
        {
            _dbContext = context;
        }
        public async Task Delete(int id)
        {
            var s = await _dbContext.Student.FindAsync(id);

            if (s != null)
            {
                _dbContext.Student.Remove(s);
                await _dbContext.SaveChangesAsync();
            }           
        }
        public async Task<Student> GetById(int id)
        {
            return await _dbContext.Student.FindAsync(id);
        }
        public async Task<IEnumerable<Student>> GetStudentsAsync(
    int? studentId = null,
    int? courseId = null,
    int? teacherId = null)
        {
            IQueryable<Student> query = _dbContext.Student;               
            
            if (studentId.HasValue)
                query = query.Where(s => s.ID == studentId.Value);

            if (courseId.HasValue)
                query = query.Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course).Where(s => s.Enrollments.Any(e => e.CourseID == courseId.Value));

            if (teacherId.HasValue)
                query = query.Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                        .ThenInclude(c => c.Teacher).Where(s => s.Enrollments.Any(e => e.Course.TeacherID == teacherId.Value));

            return await query.ToListAsync();
        }

        public async Task Insert(Student student)
        {
            await _dbContext.Student.AddAsync(student);     
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(Student student)
        {
            _dbContext.Entry(student).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

       
    }
}
