using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StarLabs_PortfolioProject.Data.Migrations
{
    public partial class remodeling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Chords");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Chords",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Chords");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Chords",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
