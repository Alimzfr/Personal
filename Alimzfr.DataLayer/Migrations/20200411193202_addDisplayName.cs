using Microsoft.EntityFrameworkCore.Migrations;

namespace Alimzfr.DataLayer.Migrations
{
    public partial class addDisplayName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Auth_User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Auth_User");
        }
    }
}
