using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class response : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Response",
                table: "RentSchedulingCars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Response",
                table: "RentSchedulingCars");
        }
    }
}
