﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFramework.Migrations
{
    /// <inheritdoc />
    public partial class foodsch3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "Foods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 50, 8, 713, DateTimeKind.Local).AddTicks(3303));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 50, 8, 713, DateTimeKind.Local).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 50, 8, 713, DateTimeKind.Local).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 50, 8, 714, DateTimeKind.Local).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 50, 8, 714, DateTimeKind.Local).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 50, 8, 714, DateTimeKind.Local).AddTicks(4309));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 50, 8, 714, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 50, 8, 714, DateTimeKind.Local).AddTicks(4317));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "Food");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 30, 10, 669, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 30, 10, 669, DateTimeKind.Local).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 30, 10, 669, DateTimeKind.Local).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 30, 10, 669, DateTimeKind.Local).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 30, 10, 669, DateTimeKind.Local).AddTicks(5746));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 30, 10, 669, DateTimeKind.Local).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 30, 10, 669, DateTimeKind.Local).AddTicks(5751));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2024, 8, 24, 22, 30, 10, 669, DateTimeKind.Local).AddTicks(5753));
        }
    }
}