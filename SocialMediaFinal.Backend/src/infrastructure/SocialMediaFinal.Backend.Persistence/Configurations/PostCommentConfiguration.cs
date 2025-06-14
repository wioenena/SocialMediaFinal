using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMediaFinal.Backend.Domain.Entities.Post;

namespace SocialMediaFinal.Backend.Persistence.Configurations;

public class PostCommentConfiguration : IEntityTypeConfiguration<PostCommentEntity> {
    public void Configure(EntityTypeBuilder<PostCommentEntity> builder) {
        _ = builder.HasKey(c => c.Id);

        _ = builder.Property(c => c.Content).IsRequired()
            .HasMaxLength(200);

        _ = builder.HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
