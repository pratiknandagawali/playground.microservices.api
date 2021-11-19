namespace Playground.Microservices.API.Controllers
{
    using Playground.Microservices.API.Commands;
    using Playground.Microservices.API.Queries;
    using Playground.Microservices.API.Requests;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> todoLogger;
        private readonly IMediator mediator;

        public TodoController(
            ILogger<TodoController> logger,
            IMediator mediator)
        {
            this.todoLogger = logger;
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets a Todo Item by Id
        /// </summary>
        /// <param name="todoId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{todoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTodoById(
            [FromRoute]int todoId,
            CancellationToken cancellationToken)
        {
            var todoRequest = new GetTodoByIdQuery(todoId);

            var result = await this.mediator.Send(todoRequest, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Creates a Todo Item
        /// </summary>
        /// <param name="todoRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTodo(
            [FromBody] TodoRequest todoRequest,
            CancellationToken cancellationToken)
        {
            var todoItemCommand = new PostTodoItemCommand(todoRequest);

            var result = await this.mediator.Send(todoItemCommand, cancellationToken);

            return CreatedAtAction(nameof(CreateTodo), result);
        }

        /// <summary>
        /// Updates a Todo Item
        /// </summary>
        /// <param name="todoRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateToDo(
            [FromBody] TodoRequest todoRequest,
            CancellationToken cancellationToken)
        {
            var todoItemCommand = new UpdateTodoItemCommand(todoRequest);

            var result = await this.mediator.Send(todoItemCommand, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Deletes a Todo Item by Id
        /// </summary>
        /// <param name="todoId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{todoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveTodo(
            [FromRoute] int todoId,
            CancellationToken cancellationToken)
        {
            var todoItemCommand = new RemoveTodoItemCommand(todoId);

            var result = await this.mediator.Send(todoItemCommand, cancellationToken);

            return Ok(result);
        }
    }
}
