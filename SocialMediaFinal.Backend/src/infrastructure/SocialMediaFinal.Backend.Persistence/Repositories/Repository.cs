
using Microsoft.EntityFrameworkCore;
using SocialMediaFinal.Backend.Domain.Entities.Common;
using SocialMediaFinal.Backend.Persistence.Contexts;

namespace SocialMediaFinal.Backend.Persistence.Repositories;

internal class Repository<TEntity>(ApplicationDbContext context) where TEntity : BaseEntity {
    protected ApplicationDbContext context = context;
    protected DbSet<TEntity> Table = context.Set<TEntity>();

}
