namespace Playground.Microservices.API.Repositories
{
    using Playground.Microservices.API.MigrationModels;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITodoRepository
    {
        /// <summary>
        /// Gets a Todo by Id
        /// </summary>
        /// <param name="todoId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TodoItem> GetByIdAsync(
            int todoId,
            CancellationToken cancellationToken);

        /// <summary>
        /// Creates a Todo Item
        /// </summary>
        /// <param name="todo"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TodoItem> AddAsync(
            TodoItem todo,
            CancellationToken cancellationToken);

        /// <summary>
        /// Updates a Todo Item
        /// </summary>
        /// <param name="todo"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TodoItem> UpdateAsync(
            TodoItem todo,
            CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a Todo Item
        /// </summary>
        /// <param name="todo"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> RemoveAsync(
            TodoItem todo,
            CancellationToken cancellationToken);
    }
}
