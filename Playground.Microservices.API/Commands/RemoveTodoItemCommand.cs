namespace Playground.Microservices.API.Commands
{
    using MediatR;

    public class RemoveTodoItemCommand : IRequest<int>
    {
        public int TodoId;

        public RemoveTodoItemCommand(int todoId) => this.TodoId = todoId;
    }
}

