using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class userhistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "UserHistory",
                newName: "Mention");

            migrationBuilder.AddColumn<bool>(
                name: "DayLate",
                table: "UserHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExternalDefects",
                table: "UserHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InternalDefects",
                table: "UserHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReturnWarranty",
                table: "UserHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayLate",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "ExternalDefects",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "InternalDefects",
                table: "UserHistory");

            migrationBuilder.DropColumn(
                name: "ReturnWarranty",
                table: "UserHistory");

            migrationBuilder.RenameColumn(
                name: "Mention",
                table: "UserHistory",
                newName: "Remarks");
        }
    }
}
