using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inz.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_id",
                table: "measures");

            migrationBuilder.UpdateData(
                table: "settings",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "value" },
                values: new object[] { "PeriodInMinutes", "60" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "measures",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "settings",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "value" },
                values: new object[] { "PeriodInHours", "1" });
        }
    }
}
