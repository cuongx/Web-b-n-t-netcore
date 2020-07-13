using Microsoft.EntityFrameworkCore.Migrations;

namespace Casetudy.Migrations
{
    public partial class InitApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    CarManufacturer = table.Column<int>(nullable: true),
                    AvatarPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AvatarPath", "CarManufacturer", "Name", "Price" },
                values: new object[] { 1, "images/cd-4.jpg", 3, "FordEverest", 8000000f });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AvatarPath", "CarManufacturer", "Name", "Price" },
                values: new object[] { 2, "images/cd-5.jpg", 4, "Lexus2019", 9000000f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
