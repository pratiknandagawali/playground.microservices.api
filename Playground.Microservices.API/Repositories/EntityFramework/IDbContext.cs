namespace Playground.Microservices.API.Repositories.EntityFramework
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    public interface IDbContext : IInfrastructure<IServiceProvider>, IDisposable
    {
        DatabaseFacade Database { get; }

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        DbSet<TEntity> Set<TEntity>()
           where TEntity : class;

        EntityEntry<TEntity> Add<TEntity>(TEntity entity)
            where TEntity : class;

        int SaveChanges();
    }
}
