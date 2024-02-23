using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rafidah.DAL.Migrations
{
    public partial class lhasbugvgfbvgb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserHourlyRate");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HourlyRateId",
                table: "AspNetUsers",
                column: "HourlyRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_HourlyRates_HourlyRateId",
                table: "AspNetUsers",
                column: "HourlyRateId",
                principalTable: "HourlyRates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_HourlyRates_HourlyRateId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HourlyRateId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "AppUserHourlyRate",
                columns: table => new
                {
                    HourlyRateId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserHourlyRate", x => new { x.HourlyRateId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AppUserHourlyRate_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserHourlyRate_HourlyRates_HourlyRateId",
                        column: x => x.HourlyRateId,
                        principalTable: "HourlyRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserHourlyRate_UsersId",
                table: "AppUserHourlyRate",
                column: "UsersId");
        }
    }
}
