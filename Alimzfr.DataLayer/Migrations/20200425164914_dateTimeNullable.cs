using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alimzfr.DataLayer.Migrations
{
    public partial class dateTimeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "GraduationDate",
                table: "Tbl_CollegeEducation",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "GraduationDate",
                table: "Tbl_CollegeEducation",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);
        }
    }
}
