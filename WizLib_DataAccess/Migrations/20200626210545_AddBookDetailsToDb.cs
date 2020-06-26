using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddBookDetailsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetail_BookDetail_Id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "FluentBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookDetail",
                table: "BookDetail");

            migrationBuilder.RenameTable(
                name: "BookDetail",
                newName: "BookDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookDetails",
                table: "BookDetails",
                column: "BookDetail_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetails_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                principalTable: "BookDetails",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetails_BookDetail_Id",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookDetails",
                table: "BookDetails");

            migrationBuilder.RenameTable(
                name: "BookDetails",
                newName: "BookDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookDetail",
                table: "BookDetail",
                column: "BookDetail_Id");

            migrationBuilder.CreateTable(
                name: "FluentBook",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentBook", x => x.Book_Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetail_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                principalTable: "BookDetail",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
