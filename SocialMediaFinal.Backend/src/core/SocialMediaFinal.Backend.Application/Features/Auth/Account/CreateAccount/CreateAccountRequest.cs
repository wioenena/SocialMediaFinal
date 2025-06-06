using MediatR;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.CreateAccount;

public sealed record CreateAccountRequest(
    string? username,
    string? password,
    string? fullName
) : IRequest<CreateAccountResponse>;
