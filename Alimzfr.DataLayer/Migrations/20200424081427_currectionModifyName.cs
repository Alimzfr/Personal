using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alimzfr.DataLayer.Migrations
{
    public partial class currectionModifyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiyDate",
                table: "Tbl_CollegeEducation");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Tbl_CollegeEducation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Tbl_CollegeEducation");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiyDate",
                table: "Tbl_CollegeEducation",
                type: "datetime2",
                nullable: true);
        }
    }
}
