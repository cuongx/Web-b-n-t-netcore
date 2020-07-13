using Microsoft.EntityFrameworkCore.Migrations;

namespace Casetudy.Migrations
{
    public partial class ExtendIdentityTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarManufacturer",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "CarbrandId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carbrands",
                columns: table => new
                {
                    CarbrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarbrandName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carbrands", x => x.CarbrandId);
                });

            migrationBuilder.InsertData(
                table: "Carbrands",
                columns: new[] { "CarbrandId", "CarbrandName" },
                values: new object[] { 1, "FORD" });

            migrationBuilder.InsertData(
                table: "Carbrands",
                columns: new[] { "CarbrandId", "CarbrandName" },
                values: new object[] { 2, "LEXUS" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarPath", "CarbrandId" },
                values: new object[] { "fOR.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarPath", "CarbrandId" },
                values: new object[] { "lAMBO.jpg", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CarbrandId",
                table: "Employees",
                column: "CarbrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Carbrands_CarbrandId",
                table: "Employees",
                column: "CarbrandId",
                principalTable: "Carbrands",
                principalColumn: "CarbrandId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Carbrands_CarbrandId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Carbrands");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CarbrandId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CarbrandId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CarManufacturer",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarPath", "CarManufacturer" },
                values: new object[] { "images/cd-4.jpg", 3 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarPath", "CarManufacturer" },
                values: new object[] { "images/cd-5.jpg", 4 });
        }
    }
}
