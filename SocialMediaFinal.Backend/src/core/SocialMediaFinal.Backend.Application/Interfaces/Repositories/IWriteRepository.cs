using SocialMediaFinal.Backend.Domain.Entities.Common;

namespace SocialMediaFinal.Backend.Application.Interfaces.Repositories;

public interface IWriteRepository<TEntity> where TEntity : BaseEntity {
    public Task<bool> AddAsync(TEntity entity);
    public bool Remove(TEntity entity);
    public bool Update(TEntity entity);
}
