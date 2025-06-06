using Microsoft.Extensions.DependencyInjection;
using SocialMediaFinal.Backend.Application.Interfaces;
using SocialMediaFinal.Backend.Persistence.Contexts;

namespace SocialMediaFinal.Backend.Persistence;

public static class ServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services) {
        _ = services.AddDbContext<ApplicationDbContext>();
        _ = services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

}
