using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class fuelConsumtion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FuelConsumption",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelConsumption",
                table: "Cars");
        }
    }
}
