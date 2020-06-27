using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddOnetToOneFluentBookAndFluentBookDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookDetail_Id",
                table: "FluentBooks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_BookDetail_Id",
                table: "FluentBooks",
                column: "BookDetail_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentBookDetails_BookDetail_Id",
                table: "FluentBooks",
                column: "BookDetail_Id",
                principalTable: "FluentBookDetails",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentBookDetails_BookDetail_Id",
                table: "FluentBooks");

            migrationBuilder.DropIndex(
                name: "IX_FluentBooks_BookDetail_Id",
                table: "FluentBooks");

            migrationBuilder.DropColumn(
                name: "BookDetail_Id",
                table: "FluentBooks");
        }
    }
}
