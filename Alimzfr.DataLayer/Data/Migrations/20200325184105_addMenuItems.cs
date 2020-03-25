using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alimzfr.Data.Migrations
{
    public partial class addMenuItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    PersianTitle = table.Column<string>(nullable: true),
                    EnglishTitle = table.Column<string>(nullable: true),
                    RoutLink = table.Column<string>(nullable: true),
                    IconName = table.Column<string>(nullable: true),
                    SequenceNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
