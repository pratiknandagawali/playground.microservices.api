namespace Playground.Microservices.API.Commands
{
    using Playground.Microservices.API.Requests;
    using Playground.Microservices.API.Response;
    using MediatR;

    public class PostTodoItemCommand : IRequest<TodoResponse>
    {
        public TodoRequest TodoRequest;

        public PostTodoItemCommand(TodoRequest todoRequest)
        {
            this.TodoRequest = todoRequest;
        }
    }
}
