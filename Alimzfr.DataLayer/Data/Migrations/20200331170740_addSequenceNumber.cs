using Microsoft.EntityFrameworkCore.Migrations;

namespace Alimzfr.Data.Migrations
{
    public partial class addSequenceNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SequenceNumber",
                table: "Tbl_Experience",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SequenceNumber",
                table: "Tbl_Experience");
        }
    }
}
