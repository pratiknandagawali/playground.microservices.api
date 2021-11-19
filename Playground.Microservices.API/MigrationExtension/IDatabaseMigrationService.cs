namespace Playground.Microservices.API.MigrationExtension
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Playground.Microservices.API.Repositories.EntityFramework;
    using Microsoft.EntityFrameworkCore;

    public interface IDatabaseMigrationService
    {
        Task<IEnumerable<string>> Migrate<TContext>()
           where TContext : DbContext, IDbContext;
    }
}
