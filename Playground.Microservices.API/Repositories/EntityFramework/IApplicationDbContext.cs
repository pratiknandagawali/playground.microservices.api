namespace Playground.Microservices.API.Repositories.EntityFramework
{
    using Playground.Microservices.API.MigrationModels;
    using Microsoft.EntityFrameworkCore;

    public interface IApplicationDbContext : IDbContext
    {
        DbSet<TodoItem> Todos { get; set; }
    }
}
