using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class Add_RoleBase_Authentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_Actions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Actions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    ActionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleActions_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleActions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ActionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActions_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserActions_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ParentId",
                table: "Actions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_ActionId",
                table: "RoleActions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_RoleId",
                table: "RoleActions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActions_ActionId",
                table: "UserActions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActions_OwnerUserId",
                table: "UserActions",
                column: "OwnerUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleActions");

            migrationBuilder.DropTable(
                name: "UserActions");

            migrationBuilder.DropTable(
                name: "Actions");
        }
    }
}
