using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HPlusSports.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Zipcode = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<string>(maxLength: 10, nullable: false),
                    ProductName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Size = table.Column<int>(nullable: true),
                    Variety = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Status = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Salesperson",
                columns: table => new
                {
                    SalespersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Zipcode = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesperson", x => x.SalespersonID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    TotalDue = table.Column<decimal>(type: "money", nullable: true),
                    Status = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CustomerID = table.Column<int>(nullable: false),
                    SalespersonID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Customer",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Salesperson",
                        column: x => x.SalespersonID,
                        principalTable: "Salesperson",
                        principalColumn: "SalespersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<string>(maxLength: 10, nullable: false),
                    Quantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product1",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerID",
                table: "Order",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_SalespersonID",
                table: "Order",
                column: "SalespersonID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItem",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductID",
                table: "OrderItem",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Salesperson");
        }
    }
}
