using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_orders_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Comment", "EmailAddress", "FirstName", "LastName", "OrderNumber", "TotalAmount", "UserName" },
                values: new object[,]
                {
                    { new Guid("0cfa8b6b-111e-48f5-9444-fb9db49b7483"), "comment for order 6", "user6@example.com", "James", "Smith", "ORD-6", 151m, "User6" },
                    { new Guid("0d451300-edbb-4ccf-86bd-b6efc5b06098"), "comment for order 5", "user5@example.com", "Emma", "Johnson", "ORD-5", 752m, "User5" },
                    { new Guid("2a510554-0de4-43cc-a4aa-1b0c7aecde92"), "comment for order 1", "user1@example.com", "Michael", "Wilson", "ORD-1", 402m, "User1" },
                    { new Guid("58448317-cb14-417b-af1a-3c2b3b4bacb7"), "comment for order 4", "user4@example.com", "Amelia", "Martinez", "ORD-4", 641m, "User4" },
                    { new Guid("8b0fef59-c999-4e4f-85e4-27bffc0feb5d"), "comment for order 3", "user3@example.com", "Sophia", "Taylor", "ORD-3", 595m, "User3" },
                    { new Guid("8c2a2a4f-0ec7-4497-96fb-364871bb5e2e"), "comment for order 2", "user2@example.com", "Emma", "Johnson", "ORD-2", 236m, "User2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("0cfa8b6b-111e-48f5-9444-fb9db49b7483"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("0d451300-edbb-4ccf-86bd-b6efc5b06098"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("2a510554-0de4-43cc-a4aa-1b0c7aecde92"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("58448317-cb14-417b-af1a-3c2b3b4bacb7"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("8b0fef59-c999-4e4f-85e4-27bffc0feb5d"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("8c2a2a4f-0ec7-4497-96fb-364871bb5e2e"));
        }
    }
}
