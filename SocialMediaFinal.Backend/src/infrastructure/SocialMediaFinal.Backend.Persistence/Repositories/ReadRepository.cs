using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SocialMediaFinal.Backend.Application.Interfaces.Repositories;
using SocialMediaFinal.Backend.Domain.Entities.Common;
using SocialMediaFinal.Backend.Persistence.Contexts;

namespace SocialMediaFinal.Backend.Persistence.Repositories;

internal sealed class ReadRepository<TEntity>(ApplicationDbContext context) : Repository<TEntity>(context), IReadRepository<TEntity> where TEntity : BaseEntity {
    public async Task<TEntity?> FindByExpressionAsync(Expression<Func<TEntity, bool>> expression) => await this.Table.FirstOrDefaultAsync(expression);

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await this.Table.ToListAsync();

    public async Task<TEntity?> GetByIdAsync(Guid id) => await this.Table.FindAsync(id);
}
