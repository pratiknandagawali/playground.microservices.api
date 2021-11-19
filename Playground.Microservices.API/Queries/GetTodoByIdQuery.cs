namespace Playground.Microservices.API.Queries
{
    using Playground.Microservices.API.Response;
    using MediatR;

    public class GetTodoByIdQuery : IRequest<TodoResponse>
    {
        public int TodoId { get; }

        public GetTodoByIdQuery(int todoId) => this.TodoId = todoId;
    }
}
