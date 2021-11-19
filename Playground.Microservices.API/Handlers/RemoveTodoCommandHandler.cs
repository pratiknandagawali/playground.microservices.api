namespace Playground.Microservices.API.Handlers
{
    using Playground.Microservices.API.Commands;
    using Playground.Microservices.API.MigrationModels;
    using Playground.Microservices.API.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveTodoCommandHandler : IRequestHandler<RemoveTodoItemCommand, int>
    {
        private readonly ITodoRepository todoRepository;

        public RemoveTodoCommandHandler(
            ITodoRepository todoRepository) => this.todoRepository = todoRepository;

        public async Task<int> Handle(
            RemoveTodoItemCommand request,
            CancellationToken cancellationToken)
        {
            var todoTobeRemoved = new TodoItem
            {
                Id = request.TodoId,
            };

            return await this.todoRepository
                .RemoveAsync(todoTobeRemoved, cancellationToken);
        }
    }
}
