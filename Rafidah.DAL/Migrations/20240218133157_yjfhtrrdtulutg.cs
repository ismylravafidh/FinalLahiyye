using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rafidah.DAL.Migrations
{
    public partial class yjfhtrrdtulutg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_AspNetUsers_AppUserId1",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_AppUserId1",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Educations");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Educations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_AppUserId",
                table: "Educations",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_AspNetUsers_AppUserId",
                table: "Educations",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_AspNetUsers_AppUserId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_AppUserId",
                table: "Educations");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Educations",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Educations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_AppUserId1",
                table: "Educations",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_AspNetUsers_AppUserId1",
                table: "Educations",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
