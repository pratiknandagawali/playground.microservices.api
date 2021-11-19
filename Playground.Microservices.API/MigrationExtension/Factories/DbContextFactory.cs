namespace Playground.Microservices.API.MigrationExtension.Factories
{
    using System;
    using Playground.Microservices.API.Repositories.EntityFramework;
    using Microsoft.EntityFrameworkCore;

    public class DbContextFactory : IDbContextFactory
    {
        public TContext Generate<TContext>(
            DbContextOptionsBuilder<TContext> dbContextOptionsBuilder)
            where TContext : DbContext, IDbContext =>
            (TContext)Activator.CreateInstance(typeof(TContext), dbContextOptionsBuilder.Options);
    }
}