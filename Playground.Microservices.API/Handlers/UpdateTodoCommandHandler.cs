namespace Playground.Microservices.API.Handlers
{
    using Playground.Microservices.API.Commands;
    using Playground.Microservices.API.MigrationModels;
    using Playground.Microservices.API.Repositories;
    using Playground.Microservices.API.Requests;
    using Playground.Microservices.API.Response;
    using Playground.Microservices.API.Services;
    using Playground.Microservices.API.Translators;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoItemCommand, TodoResponse>
    {
        private readonly ITodoRepository todoRepository;
        private readonly ITranslate<TodoRequest, TodoItem> todoItemTranslate;
        private readonly ITranslate<TodoItem, TodoResponse> todoResponseTranslate;
        private readonly IDateTimeService dateTimeService;

        public UpdateTodoCommandHandler(
            ITodoRepository todoRepository,
            ITranslate<TodoRequest, TodoItem> todoItemTranslate,
            ITranslate<TodoItem, TodoResponse> todoResponseTranslate,
            IDateTimeService dateTimeService)
        {
            this.todoRepository = todoRepository;
            this.todoItemTranslate = todoItemTranslate;
            this.todoResponseTranslate = todoResponseTranslate;
            this.dateTimeService = dateTimeService;
        }

        public async Task<TodoResponse> Handle(
            UpdateTodoItemCommand request,
            CancellationToken cancellationToken)
        {
            var todoItem = this.todoItemTranslate.Map(request.TodoRequest);
            todoItem.ModifiedTimeStamp = this.dateTimeService.GetNow();

            var todoItemResult = await this.todoRepository
                .UpdateAsync(todoItem, cancellationToken);

            return this.todoResponseTranslate.Map(todoItemResult);
        }
    }
}
