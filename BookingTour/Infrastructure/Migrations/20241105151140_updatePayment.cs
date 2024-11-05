using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatePayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "payment_date", "payment_method" },
                values: new object[] { new DateTime(2024, 11, 5, 22, 11, 39, 996, DateTimeKind.Local).AddTicks(4118), "Thẻ ví" });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "payment_id",
                keyValue: -1,
                columns: new[] { "payment_date", "payment_method" },
                values: new object[] { new DateTime(2024, 11, 5, 22, 11, 39, 996, DateTimeKind.Local).AddTicks(4116), "Tiền mặt" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "payment_date", "payment_method" },
                values: new object[] { new DateTime(2024, 11, 5, 21, 43, 59, 97, DateTimeKind.Local).AddTicks(8826), "Tiền mặt" });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "payment_id",
                keyValue: -1,
                columns: new[] { "payment_date", "payment_method" },
                values: new object[] { new DateTime(2024, 11, 5, 21, 43, 59, 97, DateTimeKind.Local).AddTicks(8824), "Thẻ tín dụng" });

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
    }
}
