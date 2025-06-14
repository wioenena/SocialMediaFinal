using MediatR;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.DeletePost;

public sealed record DeletePostRequest(Guid id) : IRequest<DeletePostResponse>;
