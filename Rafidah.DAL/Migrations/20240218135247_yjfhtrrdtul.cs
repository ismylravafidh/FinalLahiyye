using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rafidah.DAL.Migrations
{
    public partial class yjfhtrrdtul : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniversityName",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniversityName",
                table: "Educations");
        }
    }
}
