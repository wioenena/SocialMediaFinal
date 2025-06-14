using SocialMediaFinal.Backend.Domain.Entities.Account;
using SocialMediaFinal.Backend.Domain.Entities.Common;

namespace SocialMediaFinal.Backend.Domain.Entities.Post;

public class PostEntity : BaseEntity {
    public required string Content { get; set; }
    public int Likes { get; set; }
    public virtual ICollection<PostCommentEntity> Comments { get; set; } = [];
    public required Guid AuthorId { get; set; }
    public virtual AccountEntity Author { get; set; } = null!;
}
