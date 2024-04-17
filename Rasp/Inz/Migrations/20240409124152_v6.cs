using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inz.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "end_time",
                table: "measures",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "settings",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "IPAdress");

            migrationBuilder.UpdateData(
                table: "settings",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "PeriodInHours");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "end_time",
                table: "measures",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "settings",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "IP Adress");

            migrationBuilder.UpdateData(
                table: "settings",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "PeriodinHours");
        }
    }
}
