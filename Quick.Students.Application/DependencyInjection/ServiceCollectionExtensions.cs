using Microsoft.Extensions.DependencyInjection;
using Quick.Students.Application.Core.Services;
using Quick.Students.Application.Persistence.Services;
using Quick.Students.Domain.Interfaces;
using Quick.Students.Infrastructure.DataAccess;
using Quick.Students.Infrastructure.DataAccess.MsSql;

namespace Quick.Students.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped(typeof(IBaseRepostitory<,>), typeof(EfGenericRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAddressesService, AddressesService>();
            services.AddScoped<IGuardianService, GuardianService>();
            services.AddScoped<IGuradianTypeService, GuradianTypeService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IFamiliesService, FamilyService>();
            return services;
        }
    }
}
