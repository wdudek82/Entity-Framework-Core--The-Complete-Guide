using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddManyToManyFluentBookAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FluentBookAuthor",
                columns: table => new
                {
                    Book_Id = table.Column<int>(nullable: false),
                    Author_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentBookAuthor", x => new { x.Author_Id, x.Book_Id });
                    table.ForeignKey(
                        name: "FK_FluentBookAuthor_FluentAuthors_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "FluentAuthors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluentBookAuthor_FluentBooks_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "FluentBooks",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookAuthor_Book_Id",
                table: "FluentBookAuthor",
                column: "Book_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentBookAuthor");
        }
    }
}
