using Microsoft.EntityFrameworkCore.Migrations;

namespace alphadinCore.Data.Migrations
{
    public partial class addSomeDataToTesterProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "TesterProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "TesterProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserBio",
                table: "TesterProfiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NickName",
                table: "TesterProfiles");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "TesterProfiles");

            migrationBuilder.DropColumn(
                name: "UserBio",
                table: "TesterProfiles");
        }
    }
}
