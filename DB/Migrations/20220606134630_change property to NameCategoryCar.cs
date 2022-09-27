using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class changepropertytoNameCategoryCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarCategory",
                table: "UserHistory",
                newName: "NameCategoryCar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameCategoryCar",
                table: "UserHistory",
                newName: "CarCategory");
        }
    }
}
