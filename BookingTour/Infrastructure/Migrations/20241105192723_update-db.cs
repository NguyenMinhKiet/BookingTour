using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "position",
                table: "TourEmployees");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "booking_id",
                keyValue: -2,
                column: "booking_date",
                value: new DateTime(2024, 11, 6, 2, 27, 22, 759, DateTimeKind.Local).AddTicks(1824));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "booking_id",
                keyValue: -1,
                column: "booking_date",
                value: new DateTime(2024, 11, 6, 2, 27, 22, 759, DateTimeKind.Local).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "payment_id",
                keyValue: -2,
                column: "payment_date",
                value: new DateTime(2024, 11, 6, 2, 27, 22, 759, DateTimeKind.Local).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "payment_id",
                keyValue: -1,
                column: "payment_date",
                value: new DateTime(2024, 11, 6, 2, 27, 22, 759, DateTimeKind.Local).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "TourDestinations",
                keyColumns: new[] { "destination_id", "tour_id" },
                keyValues: new object[] { -2, -2 },
                column: "visit_date",
                value: new DateTime(2024, 11, 6, 2, 27, 22, 759, DateTimeKind.Local).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "TourDestinations",
                keyColumns: new[] { "destination_id", "tour_id" },
                keyValues: new object[] { -1, -1 },
                column: "visit_date",
                value: new DateTime(2024, 11, 6, 2, 27, 22, 759, DateTimeKind.Local).AddTicks(1730));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "position",
                table: "TourEmployees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "booking_id",
                keyValue: -2,
                column: "booking_date",
                value: new DateTime(2024, 11, 5, 22, 11, 39, 996, DateTimeKind.Local).AddTicks(4097));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "booking_id",
                keyValue: -1,
                column: "booking_date",
                value: new DateTime(2024, 11, 5, 22, 11, 39, 996, DateTimeKind.Local).AddTicks(4095));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "payment_id",
                keyValue: -2,
                column: "payment_date",
                value: new DateTime(2024, 11, 5, 22, 11, 39, 996, DateTimeKind.Local).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "payment_id",
                keyValue: -1,
                column: "payment_date",
                value: new DateTime(2024, 11, 5, 22, 11, 39, 996, DateTimeKind.Local).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "TourDestinations",
                keyColumns: new[] { "destination_id", "tour_id" },
                keyValues: new object[] { -2, -2 },
                column: "visit_date",
                value: new DateTime(2024, 11, 5, 22, 11, 39, 996, DateTimeKind.Local).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "TourDestinations",
                keyColumns: new[] { "destination_id", "tour_id" },
                keyValues: new object[] { -1, -1 },
                column: "visit_date",
                value: new DateTime(2024, 11, 5, 22, 11, 39, 996, DateTimeKind.Local).AddTicks(4028));

            migrationBuilder.UpdateData(
                table: "TourEmployees",
                keyColumns: new[] { "employee_id", "tour_id" },
                keyValues: new object[] { -3, -2 },
                column: "position",
                value: "Tài xế");

            migrationBuilder.UpdateData(
                table: "TourEmployees",
                keyColumns: new[] { "employee_id", "tour_id" },
                keyValues: new object[] { -2, -2 },
                column: "position",
                value: "Hướng dẫn viên");

            migrationBuilder.UpdateData(
                table: "TourEmployees",
                keyColumns: new[] { "employee_id", "tour_id" },
                keyValues: new object[] { -3, -1 },
                column: "position",
                value: "Tài xế");

            migrationBuilder.UpdateData(
                table: "TourEmployees",
                keyColumns: new[] { "employee_id", "tour_id" },
                keyValues: new object[] { -2, -1 },
                column: "position",
                value: "Hướng dẫn viên");
        }
    }
}
