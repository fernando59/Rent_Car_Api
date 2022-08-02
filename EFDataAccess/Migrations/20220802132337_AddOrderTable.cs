using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccess.Migrations
{
    public partial class AddOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderReservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    days = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderReservation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderReservation_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "832820ac-1b08-444f-a181-cb53552ec970",
                column: "ConcurrencyStamp",
                value: "4950b87f-981b-4380-8c68-df04ce78a183");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ade430d8-7c00-4fb4-96e7-b4531617964e",
                column: "ConcurrencyStamp",
                value: "1f2360eb-851a-4f32-974b-99fc88248ecc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd48176-a1c3-4b29-9c74-72b2d8bb688d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce9650ef-0f59-4765-bb39-df1f356cdc7f", "AQAAAAEAACcQAAAAEKuny19FN7XZiOB9dG6BGCHJcH//8poDcu/Wgae6Na9nnY8t/TVYGtM3Uwa0G7xVFA==", "b87d883f-2c34-4332-b5f5-7a2caa1aa1f4" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderReservation_UserId",
                table: "OrderReservation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReservation_VehicleId",
                table: "OrderReservation",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderReservation");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "832820ac-1b08-444f-a181-cb53552ec970",
                column: "ConcurrencyStamp",
                value: "68cf7020-ea91-4c41-beb9-e9399dad2949");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ade430d8-7c00-4fb4-96e7-b4531617964e",
                column: "ConcurrencyStamp",
                value: "1ee4ba1f-7549-47b0-8493-cc3bc51b2329");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd48176-a1c3-4b29-9c74-72b2d8bb688d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dff01d8-6fb0-4c36-9085-a2969afc42bf", "AQAAAAEAACcQAAAAEMx8gCYgWUs8lNKXcjTfL2CWjknW7JHzlI6ux9FErHlpYxIKXJjbBzkpMH4bemYQfw==", "a60619aa-f76a-4462-8ab9-aee9e94d0398" });
        }
    }
}
