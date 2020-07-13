using Microsoft.EntityFrameworkCore.Migrations;

namespace Casetudy.Migrations
{
    public partial class CreateDescriptionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    DescriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.DescriptionId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDescriptions",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    DescriptionId = table.Column<int>(nullable: false),
                    EmployeesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDescriptions", x => new { x.EmployeeId, x.DescriptionId });
                    table.ForeignKey(
                        name: "FK_EmployeeDescriptions_Descriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "Descriptions",
                        principalColumn: "DescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDescriptions_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Descriptions",
                columns: new[] { "DescriptionId", "OriginName" },
                values: new object[,]
                {
                    { 1, "Anh Quốc" },
                    { 2, "Hoa Kì" },
                    { 3, "Việt Nam" },
                    { 4, "Italia" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeDescriptions",
                columns: new[] { "EmployeeId", "DescriptionId", "EmployeesId" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 2, 1, null },
                    { 3, 2, null },
                    { 4, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDescriptions_DescriptionId",
                table: "EmployeeDescriptions",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDescriptions_EmployeesId",
                table: "EmployeeDescriptions",
                column: "EmployeesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDescriptions");

            migrationBuilder.DropTable(
                name: "Descriptions");
        }
    }
}
