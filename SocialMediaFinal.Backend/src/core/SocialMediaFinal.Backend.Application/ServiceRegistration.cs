using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMediaFinal.Backend.Application.Behaviors;
using SocialMediaFinal.Backend.Application.Interfaces.Services;
using SocialMediaFinal.Backend.Application.Options;
using SocialMediaFinal.Backend.Application.Services;

namespace SocialMediaFinal.Backend.Application;

public static class ServiceRegistration {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) {
        var asm = Assembly.GetExecutingAssembly();
        _ = services.AddValidatorsFromAssembly(asm);
        _ = services.AddMediatR(o => {
            _ = o.RegisterServicesFromAssembly(asm);
            _ = o.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        _ = services.AddSingleton<IPasswordService, PasswordService>();
        _ = services.AddSingleton<IJWTService, JWTService>();
        _ = services.Configure<JWTOptions>(configuration.GetSection("JWTSettings"));
        return services;
    }
}
