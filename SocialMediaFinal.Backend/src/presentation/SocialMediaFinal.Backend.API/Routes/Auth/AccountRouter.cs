namespace SocialMediaFinal.Backend.API.Routes.Auth;

public static class AccountRouter {
    public static void MapAccountRoutes(this IEndpointRouteBuilder builder) {
        var group = builder
                        .MapGroup("/auth/account")
                        .WithTags("Account");

        _ = group.MapGet("/register", Register).WithName("Register");
    }

    private static IResult Register() => Results.Ok(new {
        message = "Registration endpoint is not implemented yet."
    });
}
