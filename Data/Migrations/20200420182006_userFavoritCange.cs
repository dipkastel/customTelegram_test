using Microsoft.EntityFrameworkCore.Migrations;

namespace alphadinCore.Data.Migrations
{
    public partial class userFavoritCange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoriteTagId",
                table: "UserFavorites");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "UserFavorites",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_TagId",
                table: "UserFavorites",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_FavoriteTags_TagId",
                table: "UserFavorites",
                column: "TagId",
                principalTable: "FavoriteTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_FavoriteTags_TagId",
                table: "UserFavorites");

            migrationBuilder.DropIndex(
                name: "IX_UserFavorites_TagId",
                table: "UserFavorites");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "UserFavorites");

            migrationBuilder.AddColumn<int>(
                name: "FavoriteTagId",
                table: "UserFavorites",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
