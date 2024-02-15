using KodlamaIo.DataAccess.Abstract;
using KodlamaIo.DataAccess.Concrete.EntityFramework.Context;
using KodlamaIo.DataAccess.Concrete.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KodlamaIo.DataAccess
{
    public static class ServiceRegistration
    {
        public static IServiceCollection DataAccessRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<KodlamaioContext>(conf =>
            {
                conf.UseSqlServer(configuration["connectionString:MSSQLServer"],a=>a.MigrationsAssembly("KodlamaIo.Entites"));
                
            });

            services.AddScoped<ICourseDal, EfCourseDal>();
            services.AddScoped<ICourseCategoryDal, EfCourseCategoryDal>();
            services.AddScoped<IInstructorDal, EfInstructorDal>();

            return services;
        }
    }
}
