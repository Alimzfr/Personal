using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alimzfr.Data.Migrations
{
    public partial class changeEducationToTrainingCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Education");

            migrationBuilder.CreateTable(
                name: "Tbl_TrainingCourse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    PersianCourseName = table.Column<string>(nullable: true),
                    EnglishCourseName = table.Column<string>(nullable: true),
                    PersianDescription = table.Column<string>(nullable: true),
                    EnglishDescription = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(type: "date", nullable: false),
                    ToDate = table.Column<DateTime>(type: "date", nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    PersianEducationalInstitute = table.Column<string>(nullable: true),
                    EnglishEducationalInstitute = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_TrainingCourse", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_TrainingCourse");

            migrationBuilder.CreateTable(
                name: "Tbl_Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    EnglishCourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishEducationalInstitute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersianCourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersianDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersianEducationalInstitute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Education", x => x.Id);
                });
        }
    }
}
