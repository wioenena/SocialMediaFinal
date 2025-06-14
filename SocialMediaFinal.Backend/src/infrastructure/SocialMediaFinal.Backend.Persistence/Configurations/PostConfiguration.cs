using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMediaFinal.Backend.Domain.Entities.Post;

namespace SocialMediaFinal.Backend.Persistence.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<PostEntity> {
    public void Configure(EntityTypeBuilder<PostEntity> builder) {
        _ = builder.HasKey(p => p.Id);

        _ = builder.Property(p => p.Content)
        .IsRequired()
        .HasMaxLength(1000);
    }
}
