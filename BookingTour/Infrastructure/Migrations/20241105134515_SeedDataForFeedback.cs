using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForFeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "feedback_id", "comments", "customer_id", "rating", "tour_id" },
                values: new object[,]
                {
                    { -2, "Hài lòng với dịch vụ.", -2, 4, -2 },
                    { -1, "Chuyến đi tuyệt vời!", -1, 5, -1 }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "feedback_id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "feedback_id",
                keyValue: -1);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "booking_id",
                keyValue: -2,
                column: "booking_date",
                value: new DateTime(2024, 11, 5, 20, 43, 47, 334, DateTimeKind.Local).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "booking_id",
                keyValue: -1,
                column: "booking_date",
                value: new DateTime(2024, 11, 5, 20, 43, 47, 334, DateTimeKind.Local).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "payment_id",
                keyValue: -2,
                column: "payment_date",
                value: new DateTime(2024, 11, 5, 20, 43, 47, 334, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "payment_id",
                keyValue: -1,
                column: "payment_date",
                value: new DateTime(2024, 11, 5, 20, 43, 47, 334, DateTimeKind.Local).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "TourDestinations",
                keyColumns: new[] { "destination_id", "tour_id" },
                keyValues: new object[] { -2, -2 },
                column: "visit_date",
                value: new DateTime(2024, 11, 5, 20, 43, 47, 334, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "TourDestinations",
                keyColumns: new[] { "destination_id", "tour_id" },
                keyValues: new object[] { -1, -1 },
                column: "visit_date",
                value: new DateTime(2024, 11, 5, 20, 43, 47, 334, DateTimeKind.Local).AddTicks(4521));
        }
    }
}
