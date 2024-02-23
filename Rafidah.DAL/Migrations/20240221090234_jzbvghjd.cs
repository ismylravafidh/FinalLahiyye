using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rafidah.DAL.Migrations
{
    public partial class jzbvghjd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkAndExperiences_Jobs_JobId",
                table: "WorkAndExperiences");

            migrationBuilder.DropTable(
                name: "CategoryJobs");

            migrationBuilder.DropIndex(
                name: "IX_WorkAndExperiences_JobId",
                table: "WorkAndExperiences");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "WorkAndExperiences");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                table: "Jobs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "WorkAndExperiences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Jobid = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryJobs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoryJobs_Jobs_Jobid",
                        column: x => x.Jobid,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkAndExperiences_JobId",
                table: "WorkAndExperiences",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryJobs_CategoryId",
                table: "CategoryJobs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryJobs_Jobid",
                table: "CategoryJobs",
                column: "Jobid");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkAndExperiences_Jobs_JobId",
                table: "WorkAndExperiences",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }
    }
}
