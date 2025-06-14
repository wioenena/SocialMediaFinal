using MediatR;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.LoginAccount;

public sealed record LoginRequest(string username, string password) : IRequest<LoginResponse>;
