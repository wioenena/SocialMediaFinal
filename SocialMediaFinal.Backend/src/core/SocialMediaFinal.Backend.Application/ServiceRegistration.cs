using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMediaFinal.Backend.Application.Behaviors;
using SocialMediaFinal.Backend.Application.Options;

namespace SocialMediaFinal.Backend.Application;

public static class ServiceRegistration {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) {
        var asm = Assembly.GetExecutingAssembly();
        _ = services.AddMediatR(config => {
            _ = config.RegisterServicesFromAssembly(asm);
            _ = config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        _ = services.AddValidatorsFromAssembly(asm);

        _ = services.Configure<JWTOptions>(configuration.GetSection("JWTSettings"));

        return services;
    }
}
