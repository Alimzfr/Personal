using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alimzfr.DataLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auth_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auth_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 450, nullable: true),
                    Email = table.Column<string>(maxLength: 450, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_About",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    PersianDescription = table.Column<string>(nullable: true),
                    EnglishDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_About", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CollegeEducation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifiyDate = table.Column<DateTime>(nullable: true),
                    PersianDegreeLevel = table.Column<string>(nullable: true),
                    EnglishDegreeLevel = table.Column<string>(nullable: true),
                    PersianAcademicField = table.Column<string>(nullable: true),
                    EnglishAcademicField = table.Column<string>(nullable: true),
                    PersianUniversity = table.Column<string>(nullable: true),
                    EnglishUniversity = table.Column<string>(nullable: true),
                    PersianDescription = table.Column<string>(nullable: true),
                    EnglishDescription = table.Column<string>(nullable: true),
                    GraduationDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CollegeEducation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Experience",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    PersianJobTitle = table.Column<string>(nullable: true),
                    EnglishJobTitle = table.Column<string>(nullable: true),
                    PersianCompanyName = table.Column<string>(nullable: true),
                    EnglishCompanyName = table.Column<string>(nullable: true),
                    PersianDescription = table.Column<string>(nullable: true),
                    EnglishDescription = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(type: "date", nullable: false),
                    ToDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsCurrentJob = table.Column<bool>(nullable: false),
                    SequenceNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Experience", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_MenuItem",
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
                    table.PrimaryKey("PK_Tbl_MenuItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SkillCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    PersianCategoryName = table.Column<string>(nullable: true),
                    EnglishCategoryName = table.Column<string>(nullable: true),
                    CategoryColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SkillCategory", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Tbl_UserMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    UserAgentInfo = table.Column<string>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auth_UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Auth_UserRole_Auth_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Auth_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auth_UserRole_Auth_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Auth_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auth_UserToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessTokenHash = table.Column<string>(nullable: true),
                    AccessTokenExpiresDateTime = table.Column<DateTimeOffset>(nullable: false),
                    RefreshTokenIdHash = table.Column<string>(maxLength: 450, nullable: false),
                    RefreshTokenIdHashSource = table.Column<string>(maxLength: 450, nullable: true),
                    RefreshTokenExpiresDateTime = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth_UserToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auth_UserToken_Auth_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Auth_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Skill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    PersianSkillName = table.Column<string>(nullable: true),
                    EnglishSkillName = table.Column<string>(nullable: true),
                    PersianDescription = table.Column<string>(nullable: true),
                    EnglishDescription = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    SkillCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Skill_Tbl_SkillCategory_SkillCategoryId",
                        column: x => x.SkillCategoryId,
                        principalTable: "Tbl_SkillCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auth_Role_Name",
                table: "Auth_Role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auth_User_Email",
                table: "Auth_User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auth_UserRole_RoleId",
                table: "Auth_UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Auth_UserRole_UserId",
                table: "Auth_UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Auth_UserToken_UserId",
                table: "Auth_UserToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Skill_SkillCategoryId",
                table: "Tbl_Skill",
                column: "SkillCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auth_UserRole");

            migrationBuilder.DropTable(
                name: "Auth_UserToken");

            migrationBuilder.DropTable(
                name: "Tbl_About");

            migrationBuilder.DropTable(
                name: "Tbl_CollegeEducation");

            migrationBuilder.DropTable(
                name: "Tbl_Experience");

            migrationBuilder.DropTable(
                name: "Tbl_MenuItem");

            migrationBuilder.DropTable(
                name: "Tbl_Skill");

            migrationBuilder.DropTable(
                name: "Tbl_TrainingCourse");

            migrationBuilder.DropTable(
                name: "Tbl_UserMessage");

            migrationBuilder.DropTable(
                name: "Auth_Role");

            migrationBuilder.DropTable(
                name: "Auth_User");

            migrationBuilder.DropTable(
                name: "Tbl_SkillCategory");
        }
    }
}
