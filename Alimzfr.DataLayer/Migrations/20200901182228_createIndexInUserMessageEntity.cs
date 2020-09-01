using Microsoft.EntityFrameworkCore.Migrations;

namespace Alimzfr.DataLayer.Migrations
{
    public partial class createIndexInUserMessageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Tbl_UserMessage",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserMessage_CreatDate",
                table: "Tbl_UserMessage",
                column: "CreatDate");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserMessage_Email",
                table: "Tbl_UserMessage",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserMessage_IsRead",
                table: "Tbl_UserMessage",
                column: "IsRead");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tbl_UserMessage_CreatDate",
                table: "Tbl_UserMessage");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_UserMessage_Email",
                table: "Tbl_UserMessage");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_UserMessage_IsRead",
                table: "Tbl_UserMessage");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Tbl_UserMessage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
