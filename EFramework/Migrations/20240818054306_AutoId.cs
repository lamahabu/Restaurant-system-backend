using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFramework.Migrations
{
    /// <inheritdoc />
    public partial class AutoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 18, 8, 43, 6, 250, DateTimeKind.Local).AddTicks(8723), "Coca-Cola", 5.0 },
                    { 2, new DateTime(2024, 8, 18, 8, 43, 6, 250, DateTimeKind.Local).AddTicks(8773), "Pepsi", 4.5 },
                    { 3, new DateTime(2024, 8, 18, 8, 43, 6, 250, DateTimeKind.Local).AddTicks(8776), "Sprite", 4.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[,]
                {
                    { -3, new DateTime(2024, 8, 18, 8, 30, 24, 134, DateTimeKind.Local).AddTicks(7014), "Sprite", 4.0 },
                    { -2, new DateTime(2024, 8, 18, 8, 30, 24, 134, DateTimeKind.Local).AddTicks(7011), "Pepsi", 4.5 },
                    { -1, new DateTime(2024, 8, 18, 8, 30, 24, 134, DateTimeKind.Local).AddTicks(6948), "Coca-Cola", 5.0 }
                });
        }
    }
}
