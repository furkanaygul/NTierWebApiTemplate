using BaseProjectTemplate._4.ServiceLayer.FluentValidations;
using FluentValidation;
using FluentValidation.AspNetCore;
namespace BaseProjectTemplate._6.Extensions
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddValidationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssemblyContaining<DemoDtoValidator>();
            services.AddFluentValidationAutoValidation(); // otomatik çalışması için

            return services;
        }
    }
}
