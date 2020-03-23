using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alimzfr.Data.Migrations
{
    public partial class initEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    PersianDescription = table.Column<string>(nullable: true),
                    EnglishDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "collegeEducations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifiyDate = table.Column<DateTime>(nullable: false),
                    PersianDegreeLevel = table.Column<string>(nullable: true),
                    EnglishDegreeLevel = table.Column<string>(nullable: true),
                    PersianAcademicField = table.Column<string>(nullable: true),
                    EnglishAcademicField = table.Column<string>(nullable: true),
                    PersianUniversity = table.Column<string>(nullable: true),
                    EnglishUniversity = table.Column<string>(nullable: true),
                    PersianDescription = table.Column<string>(nullable: true),
                    EnglishDescription = table.Column<string>(nullable: true),
                    GraduationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collegeEducations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    PersianCourseName = table.Column<string>(nullable: true),
                    EnglishCourseName = table.Column<string>(nullable: true),
                    PersianDescription = table.Column<string>(nullable: true),
                    EnglishDescription = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    PersianEducationalInstitute = table.Column<string>(nullable: true),
                    EnglishEducationalInstitute = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifiyDate = table.Column<DateTime>(nullable: false),
                    PersianJobTitle = table.Column<string>(nullable: true),
                    EnglishJobTitle = table.Column<string>(nullable: true),
                    PersianCompanyName = table.Column<string>(nullable: true),
                    EnglishCompanyName = table.Column<string>(nullable: true),
                    PersianDescription = table.Column<string>(nullable: true),
                    EnglishDescription = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    IsCurrentJob = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    PersianSkillName = table.Column<string>(nullable: true),
                    EnglishSkillName = table.Column<string>(nullable: true),
                    PersianDescription = table.Column<string>(nullable: true),
                    EnglishDescription = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "collegeEducations");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
