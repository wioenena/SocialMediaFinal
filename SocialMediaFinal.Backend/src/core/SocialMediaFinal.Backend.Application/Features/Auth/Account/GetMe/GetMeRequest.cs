using MediatR;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.GetMe;

public sealed record GetMeRequest : IRequest<GetMeResponse>;
