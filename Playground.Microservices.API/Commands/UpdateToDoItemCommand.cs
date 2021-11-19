namespace Playground.Microservices.API.Commands
{
    using Playground.Microservices.API.Requests;
    using Playground.Microservices.API.Response;
    using MediatR;

    public class UpdateTodoItemCommand : IRequest<TodoResponse>
    {
        public TodoRequest TodoRequest;

        public UpdateTodoItemCommand(TodoRequest todoRequest)
        {
            this.TodoRequest = todoRequest;
        }
    }
}