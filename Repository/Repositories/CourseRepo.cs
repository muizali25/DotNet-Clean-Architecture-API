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
    public class CourseRepo : ICourseRepo
    {
        CleanArchitectureContext _dbContext;
        public CourseRepo(CleanArchitectureContext context)
        {
            _dbContext = context;
        }
        public async Task Delete(int id)
        {
            var c = await _dbContext.Course.FindAsync(id);

            if (c != null)
            {
                _dbContext.Course.Remove(c);
                await _dbContext.SaveChangesAsync();
            }           
        }
        public async Task<Course?> GetById(int id)
        { 
            return await _dbContext.Course.FindAsync(id);
        }
        public async Task<IEnumerable<Course>> GetList(int? studentId = null,
    int? courseId = null,
    int? teacherId = null)
        {
            IQueryable<Course> query = _dbContext.Course
                .Include(t => t.Teacher)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Student);

            if (studentId.HasValue)
                query = query.Where(s => s.ID == studentId.Value);

            if (courseId.HasValue)
                query = query.Where(s => s.Enrollments.Any(e => e.CourseID == courseId.Value));

            if (teacherId.HasValue)
                query = query.Where(s => s.Enrollments.Any(e => e.Course.TeacherID == teacherId.Value));

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCourseByStudentId(int studentId)
        {
            return await _dbContext.Course.
                Where(e => e.Enrollments.Any(x => x.StudentID == studentId))
                .ToListAsync();
        }
        public async Task Insert(Course course)
        {
            await _dbContext.Course.AddAsync(course);  
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(Course course)
        {
            _dbContext.Entry(course).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
