using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class tractioncolomn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Traction",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Traction",
                table: "Cars");
        }
    }
}
