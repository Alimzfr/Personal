using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alimzfr.Data.Migrations
{
    public partial class currectionPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiyDate",
                table: "Experiences");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Experiences",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Experiences");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiyDate",
                table: "Experiences",
                type: "datetime2",
                nullable: true);
        }
    }
}
