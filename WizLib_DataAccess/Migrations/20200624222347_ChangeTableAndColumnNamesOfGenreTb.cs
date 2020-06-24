using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class ChangeTableAndColumnNamesOfGenreTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Gengres",
                table: "Gengres");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Gengres");

            migrationBuilder.RenameTable(
                name: "Gengres",
                newName: "tb_Genre");

            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "tb_Genre",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "tb_Genre",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Genre",
                table: "tb_Genre",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Genre",
                table: "tb_Genre");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "tb_Genre");

            migrationBuilder.RenameTable(
                name: "tb_Genre",
                newName: "Gengres");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Gengres",
                newName: "GenreName");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Gengres",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gengres",
                table: "Gengres",
                column: "GenreId");
        }
    }
}
