using Microsoft.EntityFrameworkCore.Migrations;

namespace alphadinCore.Data.Migrations
{
    public partial class removeSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolCourses");

            migrationBuilder.DropTable(
                name: "SchoolQuisQuestionOptions");

            migrationBuilder.DropTable(
                name: "SchoolQuizCourses");

            migrationBuilder.DropTable(
                name: "SchoolUnits");

            migrationBuilder.DropTable(
                name: "SchoolTopics");

            migrationBuilder.DropTable(
                name: "SchoolQuizQuestions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolQuisQuestionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolQuisQuestionOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolQuizQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrectAnswerId = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolQuizQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolQuizCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "SchoolCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadTime = table.Column<int>(type: "int", nullable: false),
                    SchoolTopicModelId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_SchoolCourses_SchoolTopicModelId",
                table: "SchoolCourses",
                column: "SchoolTopicModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolQuizCourses_QuestionId",
                table: "SchoolQuizCourses",
                column: "QuestionId");
        }
    }
}
