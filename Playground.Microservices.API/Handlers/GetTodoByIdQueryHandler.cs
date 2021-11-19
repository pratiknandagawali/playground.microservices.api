namespace Playground.Microservices.API.Handlers
{
    using Playground.Microservices.API.MigrationModels;
    using Playground.Microservices.API.Queries;
    using Playground.Microservices.API.Repositories;
    using Playground.Microservices.API.Response;
    using Playground.Microservices.API.Translators;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoResponse>
    {
        private readonly ITodoRepository todoRepository;
        private readonly ITranslate<TodoItem, TodoResponse> todoTranslate;

        public GetTodoByIdQueryHandler(
            ITodoRepository todoRepository,
            ITranslate<TodoItem, TodoResponse> todoTranslate)
        {
            this.todoRepository = todoRepository;
            this.todoTranslate = todoTranslate;
        }

        public async Task<TodoResponse> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            var todoItem = await this.todoRepository.GetByIdAsync(
                request.TodoId,
                cancellationToken);

            return todoItem == null ? null : this.todoTranslate.Map(todoItem);
        }
    }
}
