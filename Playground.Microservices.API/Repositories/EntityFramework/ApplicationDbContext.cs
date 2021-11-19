namespace Playground.Microservices.API.Repositories.EntityFramework
{
    using Playground.Microservices.API.MigrationModels;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configuration.TodoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
