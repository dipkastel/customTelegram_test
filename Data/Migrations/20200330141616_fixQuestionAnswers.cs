using Microsoft.EntityFrameworkCore.Migrations;

namespace alphadinCore.Data.Migrations
{
    public partial class fixQuestionAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrectAnswer",
                table: "SchoolQuizQuestions");

            migrationBuilder.DropColumn(
                name: "CurrectAnswerId",
                table: "SchoolQuizQuestions");

            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "SchoolQuizQuestions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "SchoolQuisQuestionOptions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "SchoolQuizQuestions");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "SchoolQuisQuestionOptions");

            migrationBuilder.AddColumn<string>(
                name: "CurrectAnswer",
                table: "SchoolQuizQuestions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrectAnswerId",
                table: "SchoolQuizQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
