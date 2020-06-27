using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class FluentAPIModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FluentAuthors",
                columns: table => new
                {
                    Author_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentAuthors", x => x.Author_Id);
                });

            migrationBuilder.CreateTable(
                name: "FluentBooks",
                columns: table => new
                {
                    Book_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(maxLength: 15, nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentBooks", x => x.Book_Id);
                });

            migrationBuilder.CreateTable(
                name: "FluentPublishers",
                columns: table => new
                {
                    Publisher_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentPublishers", x => x.Publisher_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentAuthors");

            migrationBuilder.DropTable(
                name: "FluentBooks");

            migrationBuilder.DropTable(
                name: "FluentPublishers");
        }
    }
}
