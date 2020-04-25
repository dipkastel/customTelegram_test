using Microsoft.EntityFrameworkCore.Migrations;

namespace alphadinCore.Data.Migrations
{
    public partial class ChangeSms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sms_User_ReciverId",
                table: "Sms");

            migrationBuilder.DropIndex(
                name: "IX_Sms_ReciverId",
                table: "Sms");

            migrationBuilder.DropColumn(
                name: "ReciverId",
                table: "Sms");

            migrationBuilder.AddColumn<string>(
                name: "Reciver",
                table: "Sms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reciver",
                table: "Sms");

            migrationBuilder.AddColumn<int>(
                name: "ReciverId",
                table: "Sms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sms_ReciverId",
                table: "Sms",
                column: "ReciverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sms_User_ReciverId",
                table: "Sms",
                column: "ReciverId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
