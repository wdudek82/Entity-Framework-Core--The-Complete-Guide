using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class ChangeNameToGenreNameInGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenreName",
                table: "Gengres",
                nullable: true);

            migrationBuilder.Sql("UPDATE dbo.Gengres SET GenreName=Name");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Gengres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Gengres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql("UPDATE dbo.Gengres SET Name=GenreName");

            migrationBuilder.DropColumn(
                name: "GenreName",
                table: "Gengres");
        }
    }
}
