using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class Add_SchoolUserLastUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolCourseCertificates_SchoolCourses_SchoolCourseId",
                table: "SchoolCourseCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolUnits_SchoolCourses_SchoolCourseId",
                table: "SchoolUnits");

            migrationBuilder.DropIndex(
                name: "IX_SchoolUnits_SchoolCourseId",
                table: "SchoolUnits");

            migrationBuilder.DropIndex(
                name: "IX_SchoolCourseCertificates_SchoolCourseId",
                table: "SchoolCourseCertificates");

            migrationBuilder.DropColumn(
                name: "SchoolCourseId",
                table: "SchoolUnits");

            migrationBuilder.DropColumn(
                name: "SchoolCourseId",
                table: "SchoolCourseCertificates");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "SchoolUnits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SchoolUserLastUnits",
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
                    CourseId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolUserLastUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolUserLastUnits_SchoolCourses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "SchoolCourses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolUserLastUnits_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolUserLastUnits_SchoolUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "SchoolUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolUnits_CourseId",
                table: "SchoolUnits",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolUserLastUnits_CourseId",
                table: "SchoolUserLastUnits",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolUserLastUnits_OwnerUserId",
                table: "SchoolUserLastUnits",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolUserLastUnits_UnitId",
                table: "SchoolUserLastUnits",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolUnits_SchoolCourses_CourseId",
                table: "SchoolUnits",
                column: "CourseId",
                principalTable: "SchoolCourses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolUnits_SchoolCourses_CourseId",
                table: "SchoolUnits");

            migrationBuilder.DropTable(
                name: "SchoolUserLastUnits");

            migrationBuilder.DropIndex(
                name: "IX_SchoolUnits_CourseId",
                table: "SchoolUnits");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "SchoolUnits");

            migrationBuilder.AddColumn<int>(
                name: "SchoolCourseId",
                table: "SchoolUnits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolCourseId",
                table: "SchoolCourseCertificates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolUnits_SchoolCourseId",
                table: "SchoolUnits",
                column: "SchoolCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolCourseCertificates_SchoolCourseId",
                table: "SchoolCourseCertificates",
                column: "SchoolCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolCourseCertificates_SchoolCourses_SchoolCourseId",
                table: "SchoolCourseCertificates",
                column: "SchoolCourseId",
                principalTable: "SchoolCourses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolUnits_SchoolCourses_SchoolCourseId",
                table: "SchoolUnits",
                column: "SchoolCourseId",
                principalTable: "SchoolCourses",
                principalColumn: "Id");
        }
    }
}
