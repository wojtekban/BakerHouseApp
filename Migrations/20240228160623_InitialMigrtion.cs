using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerHouseApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfProduction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    StandardCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressCityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressZipCode = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NipNum = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breads");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
