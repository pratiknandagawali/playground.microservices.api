namespace Playground.Microservices.API.MigrationExtension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Playground.Microservices.API.MigrationExtension.Factories;
    using Playground.Microservices.API.Repositories.EntityFramework;
    using Playground.Microservices.API.Settings;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class DatabaseMigrationService : IDatabaseMigrationService
    {
        private readonly ILoggerFactory loggerFactory;
        private readonly IDbContextFactory dbContextFactory;
        private readonly ILogger<DatabaseMigrationService> logger;
        private readonly IOptions<DatabaseConnection> settings;

        public DatabaseMigrationService(
            IDbContextFactory dbContextFactory,
            ILoggerFactory loggerFactory,
            ILogger<DatabaseMigrationService> logger,
            IOptions<DatabaseConnection> settings)
        {
            this.loggerFactory = loggerFactory;
            this.dbContextFactory = dbContextFactory;
            this.logger = logger;
            this.settings = settings;
        }

        public async Task<IEnumerable<string>> Migrate<TContext>()
            where TContext : DbContext, IDbContext
        {
            var connectionString = this.settings.Value.ConnectionString;

            var dbContextOptions = new DbContextOptionsBuilder<TContext>();
            dbContextOptions
                .UseLoggerFactory(this.loggerFactory)
                .UseSqlServer(connectionString, options =>
                {
                    options.CommandTimeout(this.settings.Value.Timeout);
                    options.EnableRetryOnFailure();
                });

            using (var context = this.dbContextFactory.Generate(dbContextOptions))
            {
                this.LogPendingMigrations(await context.Database.GetPendingMigrationsAsync());
                await context.Database.MigrateAsync();
                return await context.Database.GetAppliedMigrationsAsync();
            }
        }

        public void LogPendingMigrations(IEnumerable<string> pendingMigrations)
        {
            if (pendingMigrations != null)
            {
                this.logger.LogInformation(
                    "All migrations applied for Connection {0}",
                    this.settings.Value.ConnectionString);
            }
            else
            {
                this.logger.LogInformation(
                    "Applying Migration to Connection String {0}",
                    this.settings.Value.ConnectionString);
                pendingMigrations.ToList().ForEach(pendingMigration =>
                {
                    this.logger.LogInformation("Applying Migration {0}", pendingMigration);
                });
            }
        }
    }
}
