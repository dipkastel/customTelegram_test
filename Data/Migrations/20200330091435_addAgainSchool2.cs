using Microsoft.EntityFrameworkCore.Migrations;

namespace alphadinCore.Data.Migrations
{
    public partial class addAgainSchool2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolQuizQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    CurrectAnswer = table.Column<string>(nullable: true),
                    CurrectAnswerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolQuizQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolTopics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolQuisQuestionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(nullable: true),
                    SchoolQuizQuestionModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolQuisQuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolQuisQuestionOptions_SchoolQuizQuestions_SchoolQuizQuestionModelId",
                        column: x => x.SchoolQuizQuestionModelId,
                        principalTable: "SchoolQuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ReadTime = table.Column<int>(nullable: false),
                    SchoolTopicModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolCourses_SchoolTopics_SchoolTopicModelId",
                        column: x => x.SchoolTopicModelId,
                        principalTable: "SchoolTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolQuizCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(nullable: true),
                    SchoolCourseModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolQuizCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolQuizCourses_SchoolQuizQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "SchoolQuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolQuizCourses_SchoolCourses_SchoolCourseModelId",
                        column: x => x.SchoolCourseModelId,
                        principalTable: "SchoolCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    SchoolCourseModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolUnits_SchoolCourses_SchoolCourseModelId",
                        column: x => x.SchoolCourseModelId,
                        principalTable: "SchoolCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolCourses_SchoolTopicModelId",
                table: "SchoolCourses",
                column: "SchoolTopicModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolQuisQuestionOptions_SchoolQuizQuestionModelId",
                table: "SchoolQuisQuestionOptions",
                column: "SchoolQuizQuestionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolQuizCourses_QuestionId",
                table: "SchoolQuizCourses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolQuizCourses_SchoolCourseModelId",
                table: "SchoolQuizCourses",
                column: "SchoolCourseModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolUnits_SchoolCourseModelId",
                table: "SchoolUnits",
                column: "SchoolCourseModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolQuisQuestionOptions");

            migrationBuilder.DropTable(
                name: "SchoolQuizCourses");

            migrationBuilder.DropTable(
                name: "SchoolUnits");

            migrationBuilder.DropTable(
                name: "SchoolQuizQuestions");

            migrationBuilder.DropTable(
                name: "SchoolCourses");

            migrationBuilder.DropTable(
                name: "SchoolTopics");
        }
    }
}
