using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class clientidstringdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullNameClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandCar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelCar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayNumber = table.Column<int>(type: "int", nullable: false),
                    StatusScheduling = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeclineReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KmTraveled = table.Column<int>(type: "int", nullable: false),
                    StartData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchedulingId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserHistory");
        }
    }
}
