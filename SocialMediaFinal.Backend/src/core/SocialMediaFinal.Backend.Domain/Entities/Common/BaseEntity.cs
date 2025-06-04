using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaFinal.Backend.Domain.Entities.Common;

public abstract class BaseEntity {
    [Column("id")]
    public Guid Id { get; set; } = Guid.CreateVersion7();
    [Column("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Column("updatedAt")]
    public DateTime? UpdatedAt { get; set; }
    [Column("isDeleted")]
    public bool IsDeleted { get; set; } = false;
}
