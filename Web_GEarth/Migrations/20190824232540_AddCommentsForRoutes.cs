using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_GEarth.Migrations
{
    public partial class AddCommentsForRoutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RouteId",
                table: "Comments",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Routes_RouteId",
                table: "Comments",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Routes_RouteId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RouteId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Comments");
        }
    }
}
