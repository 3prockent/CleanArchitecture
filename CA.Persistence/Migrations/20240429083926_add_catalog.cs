using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_catalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Orders",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Orders",
                newName: "OrderNumber");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Orders",
                newName: "TotalAmount");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price", "Summary" },
                values: new object[,]
                {
                    { new Guid("0cfa8b6b-111e-48f5-9444-fb9db49b7483"), "Gaming Monitors", "Samsung Odyssey G9 Gaming Monitor", 1299.00m, "Immerse yourself in the game with this curved monitor featuring a high refresh rate and stunning visuals." },
                    { new Guid("0d451300-edbb-4ccf-86bd-b6efc5b06098"), "Gaming Peripherals", "Logitech G502 Gaming Mouse", 59.00m, "A high-performance wired mouse with customizable buttons and RGB lighting for ultimate control." },
                    { new Guid("2a510554-0de4-43cc-a4aa-1b0c7aecde92"), "Gaming Console", "PlayStation 5", 499.00m, "The next generation console with powerful graphics and immersive gaming experience." },
                    { new Guid("58448317-cb14-417b-af1a-3c2b3b4bacb7"), "Gaming Peripherals", "Razer BlackWidow Keyboard", 149.00m, "A mechanical keyboard with customizable Chroma RGB lighting for enhanced gaming performance." },
                    { new Guid("8b0fef59-c999-4e4f-85e4-27bffc0feb5d"), "Graphics Card", "NVIDIA RTX 3080", 699.00m, "Take your graphics to the next level with this high-performance graphics card." },
                    { new Guid("8c2a2a4f-0ec7-4497-96fb-364871bb5e2e"), "Gaming Console", "Xbox Series X", 499.00m, "Experience incredible speed and power with the fastest, most powerful Xbox ever made." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Orders",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Orders",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "OrderNumber",
                table: "Orders",
                newName: "ContactName");
        }
    }
}
