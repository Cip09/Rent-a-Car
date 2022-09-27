using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class rent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishDate",
                table: "RentSchedulingCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "RentSchedulingCars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Answer",
                table: "RentSchedulingCars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChildSeatOption",
                table: "RentSchedulingCars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CompletName",
                table: "RentSchedulingCars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Gps",
                table: "RentSchedulingCars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiv",
                table: "RentSchedulingCars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Mention",
                table: "RentSchedulingCars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDay",
                table: "RentSchedulingCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PayMethod",
                table: "RentSchedulingCars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "RentSchedulingCars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReturnLocation",
                table: "RentSchedulingCars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReturnTime",
                table: "RentSchedulingCars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SnowChains",
                table: "RentSchedulingCars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TakeLocation",
                table: "RentSchedulingCars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TakeTime",
                table: "RentSchedulingCars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WindshieldFluid",
                table: "RentSchedulingCars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "ChildSeatOption",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "CompletName",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "Gps",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "IsActiv",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "Mention",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "NumberOfDay",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "PayMethod",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "ReturnLocation",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "ReturnTime",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "SnowChains",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "TakeLocation",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "TakeTime",
                table: "RentSchedulingCars");

            migrationBuilder.DropColumn(
                name: "WindshieldFluid",
                table: "RentSchedulingCars");

            migrationBuilder.AlterColumn<string>(
                name: "FinishDate",
                table: "RentSchedulingCars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
