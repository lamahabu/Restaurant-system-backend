using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFramework.Migrations
{
    /// <inheritdoc />
    public partial class SeedFood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2024, 8, 18, 11, 8, 20, 988, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2024, 8, 18, 11, 8, 20, 988, DateTimeKind.Local).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2024, 8, 18, 11, 8, 20, 988, DateTimeKind.Local).AddTicks(9030));

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 18, 11, 8, 20, 989, DateTimeKind.Local).AddTicks(2033), "Burger", 10.0 },
                    { 2, new DateTime(2024, 8, 18, 11, 8, 20, 989, DateTimeKind.Local).AddTicks(2053), "Pizza", 20.0 },
                    { 3, new DateTime(2024, 8, 18, 11, 8, 20, 989, DateTimeKind.Local).AddTicks(2056), "Fries", 30.0 },
                    { 4, new DateTime(2024, 8, 18, 11, 8, 20, 989, DateTimeKind.Local).AddTicks(2058), "Sandwich", 40.0 },
                    { 5, new DateTime(2024, 8, 18, 11, 8, 20, 989, DateTimeKind.Local).AddTicks(2060), "Pasta", 50.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2024, 8, 18, 8, 43, 6, 250, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2024, 8, 18, 8, 43, 6, 250, DateTimeKind.Local).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2024, 8, 18, 8, 43, 6, 250, DateTimeKind.Local).AddTicks(8776));
        }
    }
}
