using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.CreatePost;
using SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.DeletePost;
using SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.GetAllPosts;
using SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.GetPostById;
using SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.UpdatePost;

namespace SocialMediaFinal.Backend.API.Routes.Auth;

public static class PostRouter {
    public static void MapPostRoutes(this IEndpointRouteBuilder builder) {
        var group = builder
                        .MapGroup("/auth/posts")
                        .WithTags("Post");

        _ = group.MapPost("/", CreatePost).WithName("CreatePost").RequireAuthorization();
        _ = group.MapGet("/{id:guid}", GetPostById).WithName("GetPostById").RequireAuthorization();
        _ = group.MapGet("/", GetAllPosts).WithName("GetAllPosts");
        _ = group.MapPut("/", UpdatePost).WithName("UpdatePost").RequireAuthorization();
        _ = group.MapDelete("/{id:guid}", DeletePost).WithName("DeletePost").RequireAuthorization();
    }

    private static async Task<IResult> CreatePost([FromBody] CreatePostRequest request, [FromServices] ISender sender, CancellationToken cancellationToken) => Results.Ok(await sender.Send(request, cancellationToken));

    private static async Task<IResult> GetPostById(Guid id, [FromServices] ISender sender, CancellationToken cancellationToken) => Results.Ok(await sender.Send(new GetPostByIdRequest(id), cancellationToken));

    private static async Task<IResult> GetAllPosts([FromServices] ISender sender, CancellationToken cancellationToken) => Results.Ok(await sender.Send(new GetAllPostsRequest(), cancellationToken));

    private static async Task<IResult> UpdatePost([FromBody] UpdatePostRequest request, [FromServices] ISender sender, CancellationToken cancellationToken) => Results.Ok(await sender.Send(request, cancellationToken));

    private static async Task<IResult> DeletePost(Guid id, [FromServices] ISender sender, CancellationToken cancellationToken) => Results.Ok(await sender.Send(new DeletePostRequest(id), cancellationToken));
}
