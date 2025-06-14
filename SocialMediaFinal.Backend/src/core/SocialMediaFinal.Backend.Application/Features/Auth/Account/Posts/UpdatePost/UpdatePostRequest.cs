using MediatR;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.UpdatePost;

public sealed record UpdatePostRequest(Guid id, string content, int likes) : IRequest<UpdatePostResponse>;
