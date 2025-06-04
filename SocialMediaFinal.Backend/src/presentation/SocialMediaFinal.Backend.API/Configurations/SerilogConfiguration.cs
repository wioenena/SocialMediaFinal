using Serilog;

namespace SocialMediaFinal.Backend.API.Configurations;

public static class SerilogConfiguration {
    public static IServiceCollection ApplySerilogConfiguration(this IServiceCollection services) {
#pragma warning disable CA1305 // Specify IFormatProvider
        var configuration = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console();
#pragma warning restore CA1305 // Specify IFormatProvider

        Log.Logger = configuration.CreateLogger();

        _ = services
                .AddLogging()
                .AddSerilog();
        return services;
    }
}
