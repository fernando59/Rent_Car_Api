using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccess.Migrations
{
    public partial class addCreateAtFieldVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createAt",
                table: "Vehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "832820ac-1b08-444f-a181-cb53552ec970",
                column: "ConcurrencyStamp",
                value: "1f25deba-4185-43e7-bc8c-85e1f2529205");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ade430d8-7c00-4fb4-96e7-b4531617964e",
                column: "ConcurrencyStamp",
                value: "4e73b8f8-1f87-4a03-a2dd-b8fc6d105c6e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd48176-a1c3-4b29-9c74-72b2d8bb688d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1958c38-35dd-4fdf-b928-1d115021bf18", "AQAAAAEAACcQAAAAEGkd70vNxovnHqFM0ACDnQDzvsBREemPNlkOUrUJcZe0Jxuq5Q54ORvP5ednTNegFA==", "382d255a-8ca9-4ab8-87e0-59173389924a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createAt",
                table: "Vehicle");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "832820ac-1b08-444f-a181-cb53552ec970",
                column: "ConcurrencyStamp",
                value: "f94cec06-812c-4f67-85d7-69fb7b8c127d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ade430d8-7c00-4fb4-96e7-b4531617964e",
                column: "ConcurrencyStamp",
                value: "42f3e8d6-a6df-4e71-9657-7d40104dcc12");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd48176-a1c3-4b29-9c74-72b2d8bb688d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02f6d041-25ac-4c79-a218-584127e1c5f0", "AQAAAAEAACcQAAAAEJZacbbuNzF4atq6heT57VTmtJaNpFUO32K3rgIJ9M5n2+79hlcfXIOICQ9r4xPY2Q==", "e72973ff-3e99-4c6c-a450-acd04efade49" });
        }
    }
}
