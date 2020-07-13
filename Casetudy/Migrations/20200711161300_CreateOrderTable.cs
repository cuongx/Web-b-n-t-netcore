using Microsoft.EntityFrameworkCore.Migrations;

namespace Casetudy.Migrations
{
    public partial class CreateOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(maxLength: 100, nullable: false),
                    EmployeesId = table.Column<int>(nullable: true),
                    Employeeee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Employeeee", "EmployeesId", "OrderName" },
                values: new object[] { 1, 0, null, "Trắng" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeesId",
                table: "Orders",
                column: "EmployeesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
