using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMediaFinal.Backend.Domain.Entities.Account;

namespace SocialMediaFinal.Backend.Persistence.Configurations;

internal sealed class AccountConfiguration : IEntityTypeConfiguration<AccountEntity> {
    public void Configure(EntityTypeBuilder<AccountEntity> builder) {
        _ = builder.ToTable("Accounts");
        _ = builder.HasIndex(a => a.Username).IsUnique();
        _ = builder.Property(a => a.Username).IsRequired(true);
    }
}
