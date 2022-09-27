using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "RentSchedulingCars");

            migrationBuilder.RenameColumn(
                name: "IsActiv",
                table: "RentSchedulingCars",
                newName: "ResponseValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResponseValue",
                table: "RentSchedulingCars",
                newName: "IsActiv");

            migrationBuilder.AddColumn<bool>(
                name: "Answer",
                table: "RentSchedulingCars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
