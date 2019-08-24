using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_GEarth.Migrations
{
    public partial class AddDateRecorded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRecorded",
                table: "Routes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRecorded",
                table: "Routes");
        }
    }
}
