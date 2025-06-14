using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMediaFinal.Backend.Application.Features.Auth.Account.CreateAccount;
using SocialMediaFinal.Backend.Application.Features.Auth.Account.GetMe;
using SocialMediaFinal.Backend.Application.Features.Auth.Account.LoginAccount;

namespace SocialMediaFinal.Backend.API.Routes.Auth;

public static class AccountRouter {
    public static void MapAccountRoutes(this IEndpointRouteBuilder builder) {
        var group = builder
                        .MapGroup("/auth/account")
                        .WithTags("Account");

        _ = group.MapPost("/register", Register).WithName("Register");
        _ = group.MapPost("/login", Login).WithName("Login");
        _ = group.MapGet("/@me", GetMe).WithName("GetMe");
    }

    private static async Task<IResult> Register([FromBody] CreateAccountRequest request, [FromServices] ISender sender, CancellationToken cancellationToken) =>
        Results.Ok(await sender.Send(request, cancellationToken));

    private static async Task<IResult> Login([FromBody] LoginRequest request, [FromServices] ISender sender, CancellationToken cancellationToken) => Results.Ok(await sender.Send(request, cancellationToken));

    private static async Task<IResult> GetMe([FromServices] ISender sender, CancellationToken cancellationToken) =>
        Results.Ok(await sender.Send(new GetMeRequest(), cancellationToken));
}
