using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_GEarth.Migrations
{
    public partial class CascadeDeleteCommentsForRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Routes_RouteId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Routes_RouteId",
                table: "Comments",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Routes_RouteId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Routes_RouteId",
                table: "Comments",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
