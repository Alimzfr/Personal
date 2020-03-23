using Microsoft.EntityFrameworkCore.Migrations;

namespace Alimzfr.Data.Migrations
{
    public partial class currectionCollageEducationsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_collegeEducations",
                table: "collegeEducations");

            migrationBuilder.RenameTable(
                name: "collegeEducations",
                newName: "CollegeEducations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollegeEducations",
                table: "CollegeEducations",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CollegeEducations",
                table: "CollegeEducations");

            migrationBuilder.RenameTable(
                name: "CollegeEducations",
                newName: "collegeEducations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_collegeEducations",
                table: "collegeEducations",
                column: "Id");
        }
    }
}
