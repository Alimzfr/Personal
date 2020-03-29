using Microsoft.EntityFrameworkCore.Migrations;

namespace Alimzfr.Data.Migrations
{
    public partial class changeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillCategories_SkillCategoryId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillCategories",
                table: "SkillCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollegeEducations",
                table: "CollegeEducations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Tbl_Skill");

            migrationBuilder.RenameTable(
                name: "SkillCategories",
                newName: "Tbl_SkillCategory");

            migrationBuilder.RenameTable(
                name: "MenuItems",
                newName: "Tbl_MenuItem");

            migrationBuilder.RenameTable(
                name: "Experiences",
                newName: "Tbl_Experience");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "Tbl_Education");

            migrationBuilder.RenameTable(
                name: "CollegeEducations",
                newName: "Tbl_CollegeEducation");

            migrationBuilder.RenameTable(
                name: "Abouts",
                newName: "Tbl_About");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_SkillCategoryId",
                table: "Tbl_Skill",
                newName: "IX_Tbl_Skill_SkillCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Skill",
                table: "Tbl_Skill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_SkillCategory",
                table: "Tbl_SkillCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_MenuItem",
                table: "Tbl_MenuItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Experience",
                table: "Tbl_Experience",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Education",
                table: "Tbl_Education",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_CollegeEducation",
                table: "Tbl_CollegeEducation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_About",
                table: "Tbl_About",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Skill_Tbl_SkillCategory_SkillCategoryId",
                table: "Tbl_Skill",
                column: "SkillCategoryId",
                principalTable: "Tbl_SkillCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Skill_Tbl_SkillCategory_SkillCategoryId",
                table: "Tbl_Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_SkillCategory",
                table: "Tbl_SkillCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Skill",
                table: "Tbl_Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_MenuItem",
                table: "Tbl_MenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Experience",
                table: "Tbl_Experience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Education",
                table: "Tbl_Education");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_CollegeEducation",
                table: "Tbl_CollegeEducation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_About",
                table: "Tbl_About");

            migrationBuilder.RenameTable(
                name: "Tbl_SkillCategory",
                newName: "SkillCategories");

            migrationBuilder.RenameTable(
                name: "Tbl_Skill",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "Tbl_MenuItem",
                newName: "MenuItems");

            migrationBuilder.RenameTable(
                name: "Tbl_Experience",
                newName: "Experiences");

            migrationBuilder.RenameTable(
                name: "Tbl_Education",
                newName: "Educations");

            migrationBuilder.RenameTable(
                name: "Tbl_CollegeEducation",
                newName: "CollegeEducations");

            migrationBuilder.RenameTable(
                name: "Tbl_About",
                newName: "Abouts");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Skill_SkillCategoryId",
                table: "Skills",
                newName: "IX_Skills_SkillCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillCategories",
                table: "SkillCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollegeEducations",
                table: "CollegeEducations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillCategories_SkillCategoryId",
                table: "Skills",
                column: "SkillCategoryId",
                principalTable: "SkillCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
