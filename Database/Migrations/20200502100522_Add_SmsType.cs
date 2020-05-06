using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class Add_SmsType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolCourseCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SchoolQuizCourseId = table.Column<int>(nullable: false),
                    SchoolCourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolCourseCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolCourseCertificates_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolCourseCertificates_SchoolCourses_SchoolCourseId",
                        column: x => x.SchoolCourseId,
                        principalTable: "SchoolCourses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolCourseCertificates_SchoolQuizCourses_SchoolQuizCourseId",
                        column: x => x.SchoolQuizCourseId,
                        principalTable: "SchoolQuizCourses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolCourseCertificates_OwnerUserId",
                table: "SchoolCourseCertificates",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolCourseCertificates_SchoolCourseId",
                table: "SchoolCourseCertificates",
                column: "SchoolCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolCourseCertificates_SchoolQuizCourseId",
                table: "SchoolCourseCertificates",
                column: "SchoolQuizCourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolCourseCertificates");
        }
    }
}
