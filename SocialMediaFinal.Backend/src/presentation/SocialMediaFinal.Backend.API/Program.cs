

using Scalar.AspNetCore;
using SocialMediaFinal.Backend.API.Configurations;
using SocialMediaFinal.Backend.API.Middlewares;
using SocialMediaFinal.Backend.API.Routes.Auth;
using SocialMediaFinal.Backend.Application;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment.EnvironmentName;
var isDevelopment = builder.Environment.IsDevelopment();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{environment}.json", optional: true);

builder.Services.AddOpenApi();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.ApplyCORSConfiguration();
builder.Services.ApplySerilogConfiguration();
builder.Services.ApplyJWTConfiguration(isDevelopment);
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();

if (isDevelopment) {
    _ = app.MapOpenApi();
    _ = app.MapScalarApiReference();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapAccountRoutes();


app.Run();
