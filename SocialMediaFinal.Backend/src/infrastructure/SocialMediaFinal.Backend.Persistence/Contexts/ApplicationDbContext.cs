using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SocialMediaFinal.Backend.Domain.Entities.Common;

namespace SocialMediaFinal.Backend.Persistence.Contexts;

public class ApplicationDbContext(IConfiguration configuration, ILoggerFactory loggerFactory) : DbContext {
    private readonly IConfiguration configuration = configuration;
    private readonly ILoggerFactory loggerFactory = loggerFactory;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        _ = optionsBuilder.UseNpgsql(this.configuration.GetConnectionString("PostgreSQL"))
        .EnableDetailedErrors()
        .UseLoggerFactory(this.loggerFactory);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
        var entries = this.ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries) {
            if (entry.State == EntityState.Added)
                entry.Property(e => e.CreatedAt).CurrentValue = DateTime.UtcNow;
            else if (entry.State == EntityState.Modified)
                entry.Property(e => e.UpdatedAt).CurrentValue = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}
