namespace Playground.Microservices.API.MigrationExtension.Factories
{
    using Playground.Microservices.API.Repositories.EntityFramework;
    using Microsoft.EntityFrameworkCore;

    public interface IDbContextFactory
    {
        TContext Generate<TContext>(
            DbContextOptionsBuilder<TContext> dbContextOptionsBuilder)
            where TContext : DbContext, IDbContext;
    }
}