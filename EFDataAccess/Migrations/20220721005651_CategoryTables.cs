using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccess.Migrations
{
    public partial class CategoryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandVehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelVehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    pathImage = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeVehicle", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TypeVehicle",
                columns: new[] { "Id", "name", "pathImage" },
                values: new object[] { 1, "Motos", null });

            migrationBuilder.InsertData(
                table: "TypeVehicle",
                columns: new[] { "Id", "name", "pathImage" },
                values: new object[] { 2, "Autos", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandVehicle");

            migrationBuilder.DropTable(
                name: "ModelVehicle");

            migrationBuilder.DropTable(
                name: "TypeVehicle");
        }
    }
}
