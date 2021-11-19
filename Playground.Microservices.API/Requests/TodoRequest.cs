namespace Playground.Microservices.API.Requests
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TodoRequest
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTimeOffset ToDoTime { get; set; }
    }
}
