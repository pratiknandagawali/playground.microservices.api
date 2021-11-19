using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Playground.Microservices.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "studio");

            migrationBuilder.CreateTable(
                name: "TodoItem",
                schema: "studio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTimeStamp = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedTimeStamp = table.Column<DateTimeOffset>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    ToDoTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItem",
                schema: "studio");
        }
    }
}
