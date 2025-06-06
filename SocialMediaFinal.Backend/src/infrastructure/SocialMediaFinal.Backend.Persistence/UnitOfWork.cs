using SocialMediaFinal.Backend.Application.Interfaces;
using SocialMediaFinal.Backend.Application.Interfaces.Repositories;
using SocialMediaFinal.Backend.Domain.Entities.Common;
using SocialMediaFinal.Backend.Persistence.Contexts;
using SocialMediaFinal.Backend.Persistence.Repositories;

namespace SocialMediaFinal.Backend.Persistence;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork {
    private readonly ApplicationDbContext context = context;
    private bool disposed;

    public IReadRepository<TEntity> GetReadRepository<TEntity>() where TEntity : BaseEntity => new ReadRepository<TEntity>(this.context);

    public IWriteRepository<TEntity> GetWriteRepository<TEntity>() where TEntity : BaseEntity => new WriteRepository<TEntity>(this.context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
        using var transaction = await this.context.Database.BeginTransactionAsync(cancellationToken);

        try {
            var result = await this.context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return result;
        } catch {
            throw;
        }
    }

    private void Dispose(bool disposing) {
        if (!this.disposed && disposing) {
            this.context.Dispose();
            this.disposed = true;
        }
    }

    public void Dispose() {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
}
