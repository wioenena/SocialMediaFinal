namespace SocialMediaFinal.Backend.Application.Options;

public sealed record JWTOptions {
    public required string Secret { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
}
