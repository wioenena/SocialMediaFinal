namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.LoginAccount;

public sealed record LoginResponse(Guid accountId, string accessToken);
