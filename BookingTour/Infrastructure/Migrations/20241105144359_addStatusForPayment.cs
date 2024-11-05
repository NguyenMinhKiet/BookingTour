using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addStatusForPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "payment_status",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "booking_id",
                keyValue: -2,
                column: "booking_date",
                value: new DateTime(2024, 11, 5, 21, 43, 59, 97, DateTimeKind.Local).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "booking_id",
                keyValue: -1,
                column: "booking_date",
                value: new DateTime(2024, 11, 5, 21, 43, 59, 97, DateTimeKind.Local).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "payment_id",
                keyValue: -2,
                columns: new[] { "payment_date", "payment_status" },
                values: new object[] { new DateTime(2024, 11, 5, 21, 43, 59, 97, DateTimeKind.Local).AddTicks(8826), 0 });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "payment_id",
                keyValue: -1,
                columns: new[] { "payment_date", "payment_status" },
                values: new object[] { new DateTime(2024, 11, 5, 21, 43, 59, 97, DateTimeKind.Local).AddTicks(8824), 0 });

            migrationBuilder.UpdateData(
                table: "TourDestinations",
                keyColumns: new[] { "destination_id", "tour_id" },
                keyValues: new object[] { -2, -2 },
                column: "visit_date",
                value: new DateTime(2024, 11, 5, 21, 43, 59, 97, DateTimeKind.Local).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "TourDestinations",
                keyColumns: new[] { "destination_id", "tour_id" },
                keyValues: new object[] { -1, -1 },
                column: "visit_date",
                value: new DateTime(2024, 11, 5, 21, 43, 59, 97, DateTimeKind.Local).AddTicks(8738));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "payment_status",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "booking_id",
                keyValue: -2,
                column: "booking_date",
                value: new DateTime(2024, 11, 5, 20, 45, 15, 118, DateTimeKind.Local).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "booking_id",
                keyValue: -1,
                column: "booking_date",
                value: new DateTime(2024, 11, 5, 20, 45, 15, 118, DateTimeKind.Local).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "payment_id",
                keyValue: -2,
                column: "payment_date",
                value: new DateTime(2024, 11, 5, 20, 45, 15, 118, DateTimeKind.Local).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "payment_id",
                keyValue: -1,
                column: "payment_date",
                value: new DateTime(2024, 11, 5, 20, 45, 15, 118, DateTimeKind.Local).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "TourDestinations",
                keyColumns: new[] { "destination_id", "tour_id" },
                keyValues: new object[] { -2, -2 },
                column: "visit_date",
                value: new DateTime(2024, 11, 5, 20, 45, 15, 118, DateTimeKind.Local).AddTicks(2989));

            migrationBuilder.UpdateData(
                table: "TourDestinations",
                keyColumns: new[] { "destination_id", "tour_id" },
                keyValues: new object[] { -1, -1 },
                column: "visit_date",
                value: new DateTime(2024, 11, 5, 20, 45, 15, 118, DateTimeKind.Local).AddTicks(2980));
        }
    }
}
