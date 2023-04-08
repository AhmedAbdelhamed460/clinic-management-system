using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinic_management__system.Migrations
{
    /// <inheritdoc />
    public partial class addschedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "daysofWeek",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "daysofWeek",
                table: "Schedules");
        }
    }
}
