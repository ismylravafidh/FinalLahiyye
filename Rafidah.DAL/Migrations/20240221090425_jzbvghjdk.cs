using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rafidah.DAL.Migrations
{
    public partial class jzbvghjdk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkAndExperiences_AspNetUsers_AppUserId1",
                table: "WorkAndExperiences");

            migrationBuilder.DropIndex(
                name: "IX_WorkAndExperiences_AppUserId1",
                table: "WorkAndExperiences");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "WorkAndExperiences");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "WorkAndExperiences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkAndExperiences_AppUserId",
                table: "WorkAndExperiences",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAndExperiences_AspNetUsers_AppUserId",
                table: "WorkAndExperiences",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkAndExperiences_AspNetUsers_AppUserId",
                table: "WorkAndExperiences");

            migrationBuilder.DropIndex(
                name: "IX_WorkAndExperiences_AppUserId",
                table: "WorkAndExperiences");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "WorkAndExperiences",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "WorkAndExperiences",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkAndExperiences_AppUserId1",
                table: "WorkAndExperiences",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAndExperiences_AspNetUsers_AppUserId1",
                table: "WorkAndExperiences",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
