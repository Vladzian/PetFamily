using Microsoft.Extensions.DependencyInjection;
using PetFamily.Application.Repositories;
using PetFamily.Infrastructure.Repositories;

namespace PetFamily.Infrastructure
{
    public static class Inject
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDBContext>();
            services.AddScoped<IVolunteersRepository, VolunteersRepository>();
            return services;
        }
    }
}
