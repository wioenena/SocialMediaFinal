using SocialMediaFinal.Backend.Domain.Entities.Account;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.GetMe;

public sealed record GetMeResponse(AccountEntity account);
