namespace Playground.Microservices.API.MigrationModels
{
    using System;

    public class BaseEntity
    {
        public DateTimeOffset CreatedTimeStamp { get; set; }

        public DateTimeOffset ModifiedTimeStamp { get; set; }
    }
}
