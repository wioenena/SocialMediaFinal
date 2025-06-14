using System.Linq.Expressions;
using SocialMediaFinal.Backend.Domain.Entities.Common;

namespace SocialMediaFinal.Backend.Application.Interfaces.Repositories;

public interface IReadRepository<TEntity> where TEntity : BaseEntity {
    public Task<TEntity?> GetByIdAsync(Guid id);
    public Task<IEnumerable<TEntity>> GetAllAsync();
    public Task<TEntity?> FindByExpressionAsync(Expression<Func<TEntity, bool>> expression);
    public IQueryable<TEntity> GetQueryable(
       Expression<Func<TEntity, bool>> filter,
       params Expression<Func<TEntity, object>>[] includes);
}
