using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFramework.Migrations
{
    /// <inheritdoc />
    public partial class foodsch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 15, 42, 345, DateTimeKind.Local).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 15, 42, 345, DateTimeKind.Local).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 15, 42, 345, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 15, 42, 345, DateTimeKind.Local).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 15, 42, 345, DateTimeKind.Local).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 15, 42, 345, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 15, 42, 345, DateTimeKind.Local).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 15, 42, 345, DateTimeKind.Local).AddTicks(4376));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 14, 32, 559, DateTimeKind.Local).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 14, 32, 559, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 14, 32, 559, DateTimeKind.Local).AddTicks(3438));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 14, 32, 559, DateTimeKind.Local).AddTicks(6383));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 14, 32, 559, DateTimeKind.Local).AddTicks(6405));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 14, 32, 559, DateTimeKind.Local).AddTicks(6407));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 14, 32, 559, DateTimeKind.Local).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 14, 32, 559, DateTimeKind.Local).AddTicks(6411));
        }
    }
}
