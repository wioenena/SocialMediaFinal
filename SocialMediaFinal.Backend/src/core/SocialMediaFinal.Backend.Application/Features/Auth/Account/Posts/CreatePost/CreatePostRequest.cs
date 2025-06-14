using MediatR;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.CreatePost;

public sealed record CreatePostRequest(
    string content
) : IRequest<CreatePostResponse>;
