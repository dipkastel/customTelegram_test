using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class addsmsResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SmsResult",
                table: "Sms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmsResult",
                table: "Sms");
        }
    }
}
