using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class retreatcartemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RetreatTemporary",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RetreatTemporary",
                table: "Cars");
        }
    }
}
