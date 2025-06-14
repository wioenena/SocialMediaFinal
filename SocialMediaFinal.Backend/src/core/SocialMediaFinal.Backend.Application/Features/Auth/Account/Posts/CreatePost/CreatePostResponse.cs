using SocialMediaFinal.Backend.Domain.Entities.Post;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.CreatePost;

public sealed record CreatePostResponse(
    PostEntity Post
);
