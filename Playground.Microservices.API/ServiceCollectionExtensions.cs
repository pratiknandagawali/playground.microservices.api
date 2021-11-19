namespace Playground.Microservices.API
{
    using Playground.Microservices.API.Handlers;
    using Playground.Microservices.API.Infrastructure;
    using Playground.Microservices.API.MigrationExtension;
    using Playground.Microservices.API.MigrationExtension.Factories;
    using Playground.Microservices.API.MigrationModels;
    using Playground.Microservices.API.Queries;
    using Playground.Microservices.API.Repositories;
    using Playground.Microservices.API.Repositories.EntityFramework;
    using Playground.Microservices.API.Requests;
    using Playground.Microservices.API.Response;
    using Playground.Microservices.API.Services;
    using Playground.Microservices.API.Settings;
    using Playground.Microservices.API.Translators;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurationServices(
         this IServiceCollection services,
         IConfiguration configuration) =>
         services
             .AddSingleton(configuration)
             .Configure<AppSettings>(configuration)
             .Configure<DatabaseConnection>(configuration.GetSection(nameof(AppSettings.ConnectionStrings)));

        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services
                .AddScoped<IApplicationDbContext, ApplicationDbContext>()
                .AddScoped<ITodoRepository, TodoRepository>();

        public static IServiceCollection AddSingletonServices(this IServiceCollection services) =>
            services
                .AddSingleton<IDateTimeService, DateTimeService>()
                .AddSingleton<IConfigurationReader<int>, ConfigurationReader<int>>()
                .AddSingleton<ITranslate<TodoItem,TodoResponse>, Translate<TodoItem, TodoResponse>>()
                .AddSingleton<ITranslate<TodoRequest, TodoItem>, Translate<TodoRequest, TodoItem>>();

        public static IServiceCollection AddMigrationServices(this IServiceCollection services) =>
            services
                .AddSingleton<IDatabaseMigrationService, DatabaseMigrationService>()
                .AddSingleton<IDbContextFactory, DbContextFactory>();
    }
}
