using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rafidah.DAL.Migrations
{
    public partial class yjfhtrrdtuyderh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Skills_AppUserId",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_AppUserId",
                table: "Skills",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Skills_AppUserId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_AppUserId",
                table: "Skills",
                column: "AppUserId");
        }
    }
}
