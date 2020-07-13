using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Casetudy.Migrations
{
    public partial class AlterOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Employeeee",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarColor",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Carname",
                table: "Orders",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Orders",
                maxLength: 100,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CarColor",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Carname",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Employeeee",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
