using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccess.Migrations
{
    public partial class addfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_BrandVehicle_BrandVehicleId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_ModelVehicle_ModelVehicleId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_TypeVehicle_TypeVehicleId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "TypeVehicleId",
                table: "Vehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ModelVehicleId",
                table: "Vehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BrandVehicleId",
                table: "Vehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "832820ac-1b08-444f-a181-cb53552ec970",
                column: "ConcurrencyStamp",
                value: "eec8d20e-79b0-4a5b-9589-ac3a9999be90");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ade430d8-7c00-4fb4-96e7-b4531617964e",
                column: "ConcurrencyStamp",
                value: "94e57014-8570-4b03-8bed-1a1b6eac6bfd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfd48176-a1c3-4b29-9c74-72b2d8bb688d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "123b0efb-86c2-40a9-b142-c34fff634e15", "AQAAAAEAACcQAAAAEFgmFQXn/GhTY/kSUeToBYE7JhNg2hjlTZ5fLy01X2lOLv2ASB+Gpp4zrETAG++mGw==", "2c38ecd9-c5ca-4721-b14f-8f56499dec8d" });

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_BrandVehicle_BrandVehicleId",
                table: "Vehicle",
                column: "BrandVehicleId",
                principalTable: "BrandVehicle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_ModelVehicle_ModelVehicleId",
                table: "Vehicle",
                column: "ModelVehicleId",
                principalTable: "ModelVehicle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_TypeVehicle_TypeVehicleId",
                table: "Vehicle",
                column: "TypeVehicleId",
                principalTable: "TypeVehicle",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_BrandVehicle_BrandVehicleId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_ModelVehicle_ModelVehicleId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_TypeVehicle_TypeVehicleId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "TypeVehicleId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModelVehicleId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandVehicleId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_BrandVehicle_BrandVehicleId",
                table: "Vehicle",
                column: "BrandVehicleId",
                principalTable: "BrandVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_ModelVehicle_ModelVehicleId",
                table: "Vehicle",
                column: "ModelVehicleId",
                principalTable: "ModelVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_TypeVehicle_TypeVehicleId",
                table: "Vehicle",
                column: "TypeVehicleId",
                principalTable: "TypeVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
