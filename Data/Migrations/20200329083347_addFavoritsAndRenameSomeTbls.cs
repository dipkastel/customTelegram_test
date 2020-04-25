using Microsoft.EntityFrameworkCore.Migrations;

namespace alphadinCore.Data.Migrations
{
    public partial class addFavoritsAndRenameSomeTbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_User_userId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_User_userId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Location_ParentId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_TesterProfile_User_userId",
                table: "TesterProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Roles_RoleId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_userLanguages_User_userId",
                table: "userLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_userTokens_User_UserId",
                table: "userTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userTokens",
                table: "userTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userLanguages",
                table: "userLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TesterProfile",
                table: "TesterProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "userTokens",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "userLanguages",
                newName: "UserLanguages");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TesterProfile",
                newName: "TesterProfiles");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameIndex(
                name: "IX_userTokens_UserId",
                table: "UserTokens",
                newName: "IX_UserTokens_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_userLanguages_userId",
                table: "UserLanguages",
                newName: "IX_UserLanguages_userId");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TesterProfile_userId",
                table: "TesterProfiles",
                newName: "IX_TesterProfiles_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Location_ParentId",
                table: "Locations",
                newName: "IX_Locations_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLanguages",
                table: "UserLanguages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TesterProfiles",
                table: "TesterProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FavoriteTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: true),
                    FavoriteTagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_userId",
                table: "UserFavorites",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Users_userId",
                table: "Educations",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Users_userId",
                table: "Jobs",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Locations_ParentId",
                table: "Locations",
                column: "ParentId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TesterProfiles_Users_userId",
                table: "TesterProfiles",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_Users_userId",
                table: "UserLanguages",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Users_userId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Users_userId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Locations_ParentId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_TesterProfiles_Users_userId",
                table: "TesterProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_Users_userId",
                table: "UserLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.DropTable(
                name: "FavoriteTags");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLanguages",
                table: "UserLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TesterProfiles",
                table: "TesterProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "userTokens");

            migrationBuilder.RenameTable(
                name: "UserLanguages",
                newName: "userLanguages");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "TesterProfiles",
                newName: "TesterProfile");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameIndex(
                name: "IX_UserTokens_UserId",
                table: "userTokens",
                newName: "IX_userTokens_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLanguages_userId",
                table: "userLanguages",
                newName: "IX_userLanguages_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TesterProfiles_userId",
                table: "TesterProfile",
                newName: "IX_TesterProfile_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_ParentId",
                table: "Location",
                newName: "IX_Location_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userTokens",
                table: "userTokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userLanguages",
                table: "userLanguages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TesterProfile",
                table: "TesterProfile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_User_userId",
                table: "Educations",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_User_userId",
                table: "Jobs",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Location_ParentId",
                table: "Location",
                column: "ParentId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TesterProfile_User_userId",
                table: "TesterProfile",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Roles_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userLanguages_User_userId",
                table: "userLanguages",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userTokens_User_UserId",
                table: "userTokens",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
