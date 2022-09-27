using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class statusscheduling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchedulingStatus",
                table: "RentSchedulingCars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchedulingStatus",
                table: "RentSchedulingCars");
        }
    }
}
