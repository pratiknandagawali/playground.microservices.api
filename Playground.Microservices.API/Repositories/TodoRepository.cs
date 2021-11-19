namespace Playground.Microservices.API.Repositories
{
    using Playground.Microservices.API.Constants;
    using Playground.Microservices.API.Infrastructure;
    using Playground.Microservices.API.MigrationModels;
    using Playground.Microservices.API.Repositories.EntityFramework;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Polly;
    using Polly.Retry;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class TodoRepository : ITodoRepository
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly AsyncRetryPolicy pollyRetryAsync;
        private readonly IConfigurationReader<int> configurationReader;

        public TodoRepository(
            IApplicationDbContext applicationDbContext,
            IConfigurationReader<int> configurationReader)
        {
            this.applicationDbContext = applicationDbContext;
            this.configurationReader = configurationReader;

            this.pollyRetryAsync = Policy.Handle<SqlException>()
                .WaitAndRetryAsync(this.configurationReader.GetValue(AppSettingsName.PollyCiruitRetryTimes)
                ,retryAttempt => TimeSpan.FromSeconds(AppSettingsName.PollyCiruitRetryWaitTime));
        }

        public async Task<TodoItem> GetByIdAsync(
            int todoId,
            CancellationToken cancellationToken)
        {
            return await this.pollyRetryAsync.ExecuteAsync(async ()=>
            {
                return await this.applicationDbContext.Todos.FindAsync(new object[] { todoId }, cancellationToken);
            });
        }

        public async Task<TodoItem> AddAsync(
            TodoItem todo,
            CancellationToken cancellationToken)
        {
            return await this.pollyRetryAsync.ExecuteAsync(async () =>
            {
                await this.applicationDbContext.Todos.AddAsync(todo, cancellationToken);

                await this.applicationDbContext.SaveChangesAsync();

                return todo;
            });
        }

        public async Task<TodoItem> UpdateAsync(
            TodoItem todo,
            CancellationToken cancellationToken)
        {
            return await this.pollyRetryAsync.ExecuteAsync(async () =>
            {
                this.applicationDbContext.Entry<TodoItem>(todo).State = EntityState.Modified;

                await this.applicationDbContext.SaveChangesAsync();

                return todo;
            });
        }

        public async Task<int> RemoveAsync(
            TodoItem todo,
            CancellationToken cancellationToken)
        {
            return await this.pollyRetryAsync.ExecuteAsync(async () =>
            {
                this.applicationDbContext.Todos.Remove(todo);

                return await this.applicationDbContext.SaveChangesAsync();
            });
        }
    }
}
