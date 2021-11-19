namespace Playground.Microservices.API.Repositories.Configuration
{
    using Playground.Microservices.API.Constants;
    using Playground.Microservices.API.MigrationModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TodoConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.ToDoTime).IsRequired();

            builder.Property(x => x.CreatedTimeStamp).IsRequired();
            builder.Property(x => x.ModifiedTimeStamp).IsRequired();

            builder.ToTable("TodoItem", SchemaName.SchemaNameAlias);
        }
    }
}
