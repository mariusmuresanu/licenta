using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_GEarth.Migrations
{
    public partial class AddDbContextEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUserRole_Users_UserId",
                table: "UserUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUserRole_UserRole_UserRoleId",
                table: "UserUserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUserRole",
                table: "UserUserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.RenameTable(
                name: "UserUserRole",
                newName: "UsersUserRoles");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "UserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_UserUserRole_UserRoleId",
                table: "UsersUserRoles",
                newName: "IX_UsersUserRoles_UserRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserUserRole_UserId",
                table: "UsersUserRoles",
                newName: "IX_UsersUserRoles_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersUserRoles",
                table: "UsersUserRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersUserRoles_Users_UserId",
                table: "UsersUserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersUserRoles_UserRoles_UserRoleId",
                table: "UsersUserRoles",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersUserRoles_Users_UserId",
                table: "UsersUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersUserRoles_UserRoles_UserRoleId",
                table: "UsersUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersUserRoles",
                table: "UsersUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UsersUserRoles",
                newName: "UserUserRole");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRole");

            migrationBuilder.RenameIndex(
                name: "IX_UsersUserRoles_UserRoleId",
                table: "UserUserRole",
                newName: "IX_UserUserRole_UserRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersUserRoles_UserId",
                table: "UserUserRole",
                newName: "IX_UserUserRole_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUserRole",
                table: "UserUserRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserRole_Users_UserId",
                table: "UserUserRole",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserRole_UserRole_UserRoleId",
                table: "UserUserRole",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
