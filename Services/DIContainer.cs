using Microsoft.Extensions.DependencyInjection;
using Repository.Interface;
using Repository.Repositories;
using Services.Interface;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class DIContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepo, StudentRepo>();
            services.AddScoped<ITeacherRepo, TeacherRepo>();
            services.AddScoped<ICourseRepo, CourseRepo>();
            services.AddScoped<IEnrollmentRepo, EnrollmentRepo>();
            
            return services;
        }
    }
}
