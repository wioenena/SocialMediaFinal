
namespace SocialMediaFinal.Backend.API.Middlewares;

public sealed class ExceptionMiddleware : IMiddleware {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        try {
            await next(context);
        } catch (Exception e) {
            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception e) {
        var statusCode = StatusCodes.Status500InternalServerError;
        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsJsonAsync(new {
            statusCode,
            message = e.Message
        });
    }
}
