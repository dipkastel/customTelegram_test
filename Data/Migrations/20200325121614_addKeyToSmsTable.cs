using Microsoft.EntityFrameworkCore.Migrations;

namespace alphadinCore.data.Migrations
{
    public partial class addKeyToSmsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Sms",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Sms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Sms");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Sms",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
