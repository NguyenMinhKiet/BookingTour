using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_AccountID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Customers_CustomerID",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Tours_TourID",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_CustomerID",
                table: "Feedbacks");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerID1",
                table: "Feedbacks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerID",
                table: "Feedbacks",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerID1",
                table: "Feedbacks",
                column: "CustomerID1",
                unique: true,
                filter: "[CustomerID1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerID",
                table: "Bookings",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_AccountID",
                table: "Customers",
                column: "AccountID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Customers_CustomerID",
                table: "Feedbacks",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Customers_CustomerID1",
                table: "Feedbacks",
                column: "CustomerID1",
                principalTable: "Customers",
                principalColumn: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Tours_TourID",
                table: "Feedbacks",
                column: "TourID",
                principalTable: "Tours",
                principalColumn: "TourID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_AccountID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Customers_CustomerID",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Customers_CustomerID1",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Tours_TourID",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_CustomerID",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_CustomerID1",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CustomerID1",
                table: "Feedbacks");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerID",
                table: "Feedbacks",
                column: "CustomerID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerID",
                table: "Bookings",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_AccountID",
                table: "Customers",
                column: "AccountID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Customers_CustomerID",
                table: "Feedbacks",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Tours_TourID",
                table: "Feedbacks",
                column: "TourID",
                principalTable: "Tours",
                principalColumn: "TourID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
