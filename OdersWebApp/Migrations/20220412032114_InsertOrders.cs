using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace OdersWebApp.Migrations
{
    public partial class InsertOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "Orders",
              columns: new[] { "OrderID", "CustomerId", "ProductId", "OrderDate", "DeliveryDate", "OrderPrice"},
              values: new object[,]
              {
                    { 1, 1, 1, DateTime.Today.AddDays(-7), DateTime.Today.AddDays(4), 20.50},
                    { 2, 3, 3, DateTime.Today.AddDays(-4), DateTime.Today.AddDays(2), 3.75},
                    { 3, 2, 2, DateTime.Today.AddDays(-4), DateTime.Today.AddDays(4), 102.35},
                    { 4, 2, 5, DateTime.Today.AddDays(-2), DateTime.Today.AddDays(3), 52.80},
                    { 5, 2, 6, DateTime.Today, DateTime.Today.AddDays(8), 20.50},
                    { 6, 1, 1, DateTime.Today, DateTime.Today.AddMonths(1), 20.50},
                    { 7, 3, 9, DateTime.Today.AddDays(2), DateTime.Today.AddDays(7), 27.45},
                    { 8, 2, 7, DateTime.Today.AddDays(1), DateTime.Today.AddMonths(2), 72.45},
                    { 9, 1, 8, DateTime.Today.AddDays(2), DateTime.Today.AddDays(7), 76.23},
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
