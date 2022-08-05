using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccess.Migrations
{
    public partial class updateOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "endDate",
                table: "OrderReservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "startDate",
                table: "OrderReservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "endDate",
                table: "OrderReservation");

            migrationBuilder.DropColumn(
                name: "startDate",
                table: "OrderReservation");

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
        }
    }
}
