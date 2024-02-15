using KodlamaIo.Business.Abstract;
using KodlamaIo.Business.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection BusinessRegistration(this IServiceCollection  services,IConfiguration configuration)
        {
            var assm = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assm);
            services.AddMediatR(conf=>conf.RegisterServicesFromAssemblies(assm));

            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<IInstructorService, InstructorManager>();
            services.AddScoped<ICourseCategoryService, CourseCategoryManager>();

            return services;
        }
    }
}
