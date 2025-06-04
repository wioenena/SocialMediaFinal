using SocialMediaFinal.Backend.Domain.Entities.Common;

namespace SocialMediaFinal.Backend.Domain.Entities.Account;

public sealed class AccountEntity : BaseEntity {
    public required string Username { get; set; }
    public required string Password { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public required string FullName { get; set; }
    public string? AccessToken { get; set; }
}
