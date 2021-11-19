namespace Playground.Microservices.API.MigrationModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TodoItem : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public DateTimeOffset ToDoTime { get; set; }
    }
}
