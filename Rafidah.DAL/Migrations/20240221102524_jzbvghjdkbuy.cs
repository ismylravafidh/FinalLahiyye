using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rafidah.DAL.Migrations
{
    public partial class jzbvghjdkbuy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_AspNetUsers_AppUserId1",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_AppUserId1",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Certificates");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Certificates",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Certificates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_AppUserId",
                table: "Certificates",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_AspNetUsers_AppUserId",
                table: "Certificates",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_AspNetUsers_AppUserId",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_AppUserId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Certificates");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Certificates",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Certificates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_AppUserId1",
                table: "Certificates",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_AspNetUsers_AppUserId1",
                table: "Certificates",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
