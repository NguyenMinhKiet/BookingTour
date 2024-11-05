using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    destination_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    destination_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.destination_id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employee_id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    tour_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tour_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    availableSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.tour_id);
                    table.CheckConstraint("CK_price", "[price] >= 0");
                    table.CheckConstraint("CK_Tour_EndDate_StartDate", "[end_Date] >= [start_Date]");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    booking_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tour_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    booking_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    num_people = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    total_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.booking_id);
                    table.CheckConstraint("CK_Booking_NumPeople", "[num_people] >= 0");
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "Customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Tours_tour_id",
                        column: x => x.tour_id,
                        principalTable: "Tours",
                        principalColumn: "tour_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    feedback_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    tour_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.feedback_id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Tours_tour_id",
                        column: x => x.tour_id,
                        principalTable: "Tours",
                        principalColumn: "tour_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourDestinations",
                columns: table => new
                {
                    tour_id = table.Column<int>(type: "int", nullable: false),
                    destination_id = table.Column<int>(type: "int", nullable: false),
                    visit_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourDestinations", x => new { x.tour_id, x.destination_id });
                    table.ForeignKey(
                        name: "FK_TourDestinations_Destinations_destination_id",
                        column: x => x.destination_id,
                        principalTable: "Destinations",
                        principalColumn: "destination_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourDestinations_Tours_tour_id",
                        column: x => x.tour_id,
                        principalTable: "Tours",
                        principalColumn: "tour_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourEmployees",
                columns: table => new
                {
                    tour_id = table.Column<int>(type: "int", nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourEmployees", x => new { x.tour_id, x.employee_id });
                    table.ForeignKey(
                        name: "FK_TourEmployees_Employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourEmployees_Tours_tour_id",
                        column: x => x.tour_id,
                        principalTable: "Tours",
                        principalColumn: "tour_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    booking_id = table.Column<int>(type: "int", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    payment_method = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_booking_id",
                        column: x => x.booking_id,
                        principalTable: "Bookings",
                        principalColumn: "booking_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customer_id", "address", "email", "first_name", "last_name", "phone" },
                values: new object[,]
                {
                    { -2, "456 Phố Huế", "tranthib@example.com", "Trần", "Thị B", "0987654321" },
                    { -1, "123 Đường Láng", "nguyenvana@example.com", "Nguyễn", "Văn A", "0123456789" }
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "destination_id", "city", "country", "description", "destination_name" },
                values: new object[,]
                {
                    { -2, "Lào Cai", "Việt Nam", "Nóc nhà Đông Dương, nơi có phong cảnh hùng vĩ và khí hậu trong lành.", "Đỉnh Fansipan" },
                    { -1, "Nha Trang", "Việt Nam", "Một bãi biển nổi tiếng với cát trắng và nước biển trong xanh.", "Bãi biển Nha Trang" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "employee_id", "address", "email", "first_name", "last_name", "phone", "position" },
                values: new object[,]
                {
                    { -4, "Q12 Tp.HCM", "nguyenminhkiet@gmail.com", "Nguyễn Minh", "Kiệt", "0932881172", 5 },
                    { -3, "Hà Nội", "phamlinh@example.com", "Phạm", "Linh", "0987231220", 3 },
                    { -2, "Hà Nội", "phamhung@example.com", "Phạm", "Hùng", "0987654320", 2 },
                    { -1, "Hồ Chí Minh", "letung@example.com", "Lê", "Tùng", "0123456780", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "tour_id", "availableSeats", "description", "end_Date", "price", "start_Date", "tour_name" },
                values: new object[,]
                {
                    { -2, 15, "Tour leo núi đầy thử thách", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2999000m, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thám hiểm núi" },
                    { -1, 20, "Tour nghỉ dưỡng tại bãi biển", new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1999000m, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Du lịch biển" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "booking_id", "booking_date", "customer_id", "num_people", "total_price", "tour_id" },
                values: new object[,]
                {
                    { -2, new DateTime(2024, 11, 5, 20, 43, 47, 334, DateTimeKind.Local).AddTicks(4573), -2, 1, 2000000m, -2 },
                    { -1, new DateTime(2024, 11, 5, 20, 43, 47, 334, DateTimeKind.Local).AddTicks(4571), -1, 2, 3000000m, -1 }
                });

            migrationBuilder.InsertData(
                table: "TourDestinations",
                columns: new[] { "destination_id", "tour_id", "visit_date" },
                values: new object[,]
                {
                    { -2, -2, new DateTime(2024, 11, 5, 20, 43, 47, 334, DateTimeKind.Local).AddTicks(4530) },
                    { -1, -1, new DateTime(2024, 11, 5, 20, 43, 47, 334, DateTimeKind.Local).AddTicks(4521) }
                });

            migrationBuilder.InsertData(
                table: "TourEmployees",
                columns: new[] { "employee_id", "tour_id", "position" },
                values: new object[,]
                {
                    { -3, -2, "Tài xế" },
                    { -2, -2, "Hướng dẫn viên" },
                    { -3, -1, "Tài xế" },
                    { -2, -1, "Hướng dẫn viên" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "payment_id", "booking_id", "payment_date", "payment_method" },
                values: new object[,]
                {
                    { -2, -2, new DateTime(2024, 11, 5, 20, 43, 47, 334, DateTimeKind.Local).AddTicks(4590), "Tiền mặt" },
                    { -1, -1, new DateTime(2024, 11, 5, 20, 43, 47, 334, DateTimeKind.Local).AddTicks(4588), "Thẻ tín dụng" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_customer_id",
                table: "Bookings",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_tour_id",
                table: "Bookings",
                column: "tour_id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_tour_id",
                table: "Feedbacks",
                column: "tour_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_booking_id",
                table: "Payments",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_TourDestinations_destination_id",
                table: "TourDestinations",
                column: "destination_id");

            migrationBuilder.CreateIndex(
                name: "IX_TourEmployees_employee_id",
                table: "TourEmployees",
                column: "employee_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "TourDestinations");

            migrationBuilder.DropTable(
                name: "TourEmployees");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
