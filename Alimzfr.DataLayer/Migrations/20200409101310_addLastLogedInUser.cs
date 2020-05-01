using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alimzfr.DataLayer.Migrations
{
    public partial class addLastLogedInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastLoggedIn",
                table: "Auth_User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoggedIn",
                table: "Auth_User");
        }
    }
}
