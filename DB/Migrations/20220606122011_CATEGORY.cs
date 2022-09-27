using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class CATEGORY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarCategory",
                table: "UserHistory",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarCategory",
                table: "UserHistory");
        }
    }
}
