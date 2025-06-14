using MediatR;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.GetPostById;

public sealed record GetPostByIdRequest(Guid id) : IRequest<GetPostByIdResponse>;
