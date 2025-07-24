using BaseProjectTemplate._2.DataAccessLayer.Abstract;
using BaseProjectTemplate._2.DataAccessLayer.Repositories.Dapper;
using BaseProjectTemplate._3.BusinessLayer.Abstract;
using BaseProjectTemplate._3.BusinessLayer.Concreate;
using BaseProjectTemplate._4.ServiceLayer.Interfaces;
using BaseProjectTemplate._4.ServiceLayer.Managers;

namespace BaseProjectTemplate._6.Extensions
{
    public static class ServiceRegistrationDI
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Repositories
            services.AddScoped<IDemoDal, DemoRepository>();

            // Services
            services.AddScoped<IDemoClassService, DemoClassManager>();

            // Diğer ayarlar burada yapılabilir (örneğin cache, policy vs.)

            return services;
        }

        public static IServiceCollection AddControllerServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IApiDemoService, ApiDemoManager>();
            return services;
        }
    }
}
