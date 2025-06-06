using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMediaFinal.Backend.Application.Features.Auth.Account.CreateAccount;

namespace SocialMediaFinal.Backend.API.Routes.Auth;

public static class AccountRouter {
    public static void MapAccountRoutes(this IEndpointRouteBuilder builder) {
        var group = builder
                        .MapGroup("/auth/account")
                        .WithTags("Account");

        _ = group.MapPost("/register", Register).WithName("Register");
    }

    private static async Task<IResult> Register([FromBody] CreateAccountRequest request, [FromServices] ISender sender, CancellationToken cancellationToken) =>
        Results.Ok(await sender.Send(request, cancellationToken));
}
