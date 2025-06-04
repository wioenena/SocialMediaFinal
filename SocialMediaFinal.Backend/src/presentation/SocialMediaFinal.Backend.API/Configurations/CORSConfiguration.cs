namespace SocialMediaFinal.Backend.API.Configurations;

public static class CORSConfiguration {
    public static IServiceCollection ApplyCORSConfiguration(this IServiceCollection services) {
        _ = services.AddCors(o => o.AddDefaultPolicy(p =>
            p.AllowAnyHeader()
             .AllowAnyOrigin() // TODO:  Change this to specific origins in production
             .AllowAnyMethod()
        ));

        return services;
    }
}
