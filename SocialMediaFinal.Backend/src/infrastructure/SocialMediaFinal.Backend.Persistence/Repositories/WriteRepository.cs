using Microsoft.EntityFrameworkCore;
using SocialMediaFinal.Backend.Application.Interfaces.Repositories;
using SocialMediaFinal.Backend.Domain.Entities.Common;
using SocialMediaFinal.Backend.Persistence.Contexts;

namespace SocialMediaFinal.Backend.Persistence.Repositories;

internal sealed class WriteRepository<TEntity>(ApplicationDbContext context) : Repository<TEntity>(context), IWriteRepository<TEntity> where TEntity : BaseEntity {
    public async Task<bool> AddAsync(TEntity entity) => (await this.Table.AddAsync(entity)).State == EntityState.Added;

    public bool Remove(TEntity entity) => this.Table.Remove(entity).State == EntityState.Deleted;

    public bool Update(TEntity entity) => this.Table.Update(entity).State == EntityState.Modified;
}
