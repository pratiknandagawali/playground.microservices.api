namespace Playground.Microservices.API.Response
{
    using System;

    public class TodoResponse : BaseResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public DateTimeOffset ToDoTime { get; set; }
    }
}
