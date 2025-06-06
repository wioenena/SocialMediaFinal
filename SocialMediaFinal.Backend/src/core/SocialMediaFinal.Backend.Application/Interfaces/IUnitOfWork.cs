using SocialMediaFinal.Backend.Application.Interfaces.Repositories;
using SocialMediaFinal.Backend.Domain.Entities.Common;

namespace SocialMediaFinal.Backend.Application.Interfaces;

public interface IUnitOfWork : IDisposable {
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    public IReadRepository<TEntity> GetReadRepository<TEntity>() where TEntity : BaseEntity;
    public IWriteRepository<TEntity> GetWriteRepository<TEntity>() where TEntity : BaseEntity;

}
