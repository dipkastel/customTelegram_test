using Microsoft.EntityFrameworkCore.Migrations;

namespace alphadinCore.Data.Migrations
{
    public partial class fixGeneralTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSocial_Users_userId",
                table: "UserSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSocial",
                table: "UserSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneralType",
                table: "GeneralType");

            migrationBuilder.RenameTable(
                name: "UserSocial",
                newName: "UserSocials");

            migrationBuilder.RenameTable(
                name: "GeneralType",
                newName: "GeneralTypes");

            migrationBuilder.RenameIndex(
                name: "IX_UserSocial_userId",
                table: "UserSocials",
                newName: "IX_UserSocials_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSocials",
                table: "UserSocials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneralTypes",
                table: "GeneralTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSocials_Users_userId",
                table: "UserSocials",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSocials_Users_userId",
                table: "UserSocials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSocials",
                table: "UserSocials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneralTypes",
                table: "GeneralTypes");

            migrationBuilder.RenameTable(
                name: "UserSocials",
                newName: "UserSocial");

            migrationBuilder.RenameTable(
                name: "GeneralTypes",
                newName: "GeneralType");

            migrationBuilder.RenameIndex(
                name: "IX_UserSocials_userId",
                table: "UserSocial",
                newName: "IX_UserSocial_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSocial",
                table: "UserSocial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneralType",
                table: "GeneralType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSocial_Users_userId",
                table: "UserSocial",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
