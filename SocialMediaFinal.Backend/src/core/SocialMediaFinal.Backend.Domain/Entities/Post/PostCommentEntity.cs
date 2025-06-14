using SocialMediaFinal.Backend.Domain.Entities.Common;

namespace SocialMediaFinal.Backend.Domain.Entities.Post;

public class PostCommentEntity : BaseEntity {
    public required string Content { get; set; }
    public Guid PostId { get; set; }
    public virtual PostEntity? Post { get; set; }
}
