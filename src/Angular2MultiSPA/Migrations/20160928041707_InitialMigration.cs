﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Angular2MultiSPA.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: true),
                    Picture = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDemographics",
                columns: table => new
                {
                    CustomerTypeID = table.Column<string>(type: "nchar(10)", nullable: false),
                    CustomerDesc = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDemographics", x => x.CustomerTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<string>(type: "nchar(5)", nullable: false),
                    Address = table.Column<string>(maxLength: 60, nullable: true),
                    City = table.Column<string>(maxLength: 15, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 40, nullable: false),
                    ContactName = table.Column<string>(maxLength: 30, nullable: true),
                    ContactTitle = table.Column<string>(maxLength: 30, nullable: true),
                    Country = table.Column<string>(maxLength: 15, nullable: true),
                    Fax = table.Column<string>(maxLength: 24, nullable: true),
                    Phone = table.Column<string>(maxLength: 24, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Region = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 60, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    City = table.Column<string>(maxLength: 15, nullable: true),
                    Country = table.Column<string>(maxLength: 15, nullable: true),
                    Extension = table.Column<string>(maxLength: 4, nullable: true),
                    FirstName = table.Column<string>(maxLength: 10, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HomePhone = table.Column<string>(maxLength: 24, nullable: true),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    Notes = table.Column<string>(type: "ntext", nullable: true),
                    Photo = table.Column<byte[]>(type: "image", nullable: true),
                    PhotoPath = table.Column<string>(maxLength: 255, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Region = table.Column<string>(maxLength: 15, nullable: true),
                    ReportsTo = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 30, nullable: true),
                    TitleOfCourtesy = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Employees",
                        column: x => x.ReportsTo,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionID = table.Column<int>(nullable: false),
                    RegionDescription = table.Column<string>(type: "nchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionID);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    ShipperID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 40, nullable: false),
                    Phone = table.Column<string>(maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.ShipperID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 60, nullable: true),
                    City = table.Column<string>(maxLength: 15, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 40, nullable: false),
                    ContactName = table.Column<string>(maxLength: 30, nullable: true),
                    ContactTitle = table.Column<string>(maxLength: 30, nullable: true),
                    Country = table.Column<string>(maxLength: 15, nullable: true),
                    Fax = table.Column<string>(maxLength: 24, nullable: true),
                    HomePage = table.Column<string>(type: "ntext", nullable: true),
                    Phone = table.Column<string>(maxLength: 24, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Region = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCustomerDemo",
                columns: table => new
                {
                    CustomerID = table.Column<string>(type: "nchar(5)", nullable: false),
                    CustomerTypeID = table.Column<string>(type: "nchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCustomerDemo", x => new { x.CustomerID, x.CustomerTypeID });
                    table.ForeignKey(
                        name: "FK_CustomerCustomerDemo_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerCustomerDemo_CustomerDemographics_CustomerTypeID",
                        column: x => x.CustomerTypeID,
                        principalTable: "CustomerDemographics",
                        principalColumn: "CustomerTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Territories",
                columns: table => new
                {
                    TerritoryID = table.Column<string>(maxLength: 20, nullable: false),
                    RegionID = table.Column<int>(nullable: false),
                    TerritoryDescription = table.Column<string>(type: "nchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territories", x => x.TerritoryID);
                    table.ForeignKey(
                        name: "FK_Territories_Region",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerID = table.Column<string>(type: "nchar(5)", nullable: true),
                    EmployeeID = table.Column<int>(nullable: true),
                    Freight = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "0"),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RequiredDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShipAddress = table.Column<string>(maxLength: 60, nullable: true),
                    ShipCity = table.Column<string>(maxLength: 15, nullable: true),
                    ShipCountry = table.Column<string>(maxLength: 15, nullable: true),
                    ShipName = table.Column<string>(maxLength: 40, nullable: true),
                    ShipPostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    ShipRegion = table.Column<string>(maxLength: 15, nullable: true),
                    ShipVia = table.Column<int>(nullable: true),
                    ShippedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Employees",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Shippers_ShipVia",
                        column: x => x.ShipVia,
                        principalTable: "Shippers",
                        principalColumn: "ShipperID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: true),
                    Discontinued = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    ProductName = table.Column<string>(maxLength: 40, nullable: false),
                    QuantityPerUnit = table.Column<string>(maxLength: 20, nullable: true),
                    ReorderLevel = table.Column<short>(nullable: true, defaultValueSql: "0"),
                    SupplierID = table.Column<int>(nullable: true),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "0"),
                    UnitsInStock = table.Column<short>(nullable: true, defaultValueSql: "0"),
                    UnitsOnOrder = table.Column<short>(nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTerritories",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false),
                    TerritoryID = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTerritories", x => new { x.EmployeeID, x.TerritoryID });
                    table.ForeignKey(
                        name: "FK_EmployeeTerritories_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeTerritories_Territories_TerritoryID",
                        column: x => x.TerritoryID,
                        principalTable: "Territories",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order Details",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Discount = table.Column<float>(nullable: false, defaultValueSql: "0"),
                    Quantity = table.Column<short>(nullable: false, defaultValueSql: "1"),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Details", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_Order Details_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order Details_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "CategoryName",
                table: "Categories",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCustomerDemo_CustomerID",
                table: "CustomerCustomerDemo",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCustomerDemo_CustomerTypeID",
                table: "CustomerCustomerDemo",
                column: "CustomerTypeID");

            migrationBuilder.CreateIndex(
                name: "City",
                table: "Customers",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "CompanyName",
                table: "Customers",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "PostalCode",
                table: "Customers",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "Region",
                table: "Customers",
                column: "Region");

            migrationBuilder.CreateIndex(
                name: "LastName",
                table: "Employees",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "PostalCode",
                table: "Employees",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsTo",
                table: "Employees",
                column: "ReportsTo");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTerritories_EmployeeID",
                table: "EmployeeTerritories",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTerritories_TerritoryID",
                table: "EmployeeTerritories",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "OrdersOrder_Details",
                table: "Order Details",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "ProductsOrder_Details",
                table: "Order Details",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "CustomersOrders",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "EmployeesOrders",
                table: "Orders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "OrderDate",
                table: "Orders",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "ShipPostalCode",
                table: "Orders",
                column: "ShipPostalCode");

            migrationBuilder.CreateIndex(
                name: "ShippersOrders",
                table: "Orders",
                column: "ShipVia");

            migrationBuilder.CreateIndex(
                name: "ShippedDate",
                table: "Orders",
                column: "ShippedDate");

            migrationBuilder.CreateIndex(
                name: "CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "ProductName",
                table: "Products",
                column: "ProductName");

            migrationBuilder.CreateIndex(
                name: "SuppliersProducts",
                table: "Products",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "CompanyName",
                table: "Suppliers",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "PostalCode",
                table: "Suppliers",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Territories_RegionID",
                table: "Territories",
                column: "RegionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCustomerDemo");

            migrationBuilder.DropTable(
                name: "EmployeeTerritories");

            migrationBuilder.DropTable(
                name: "Order Details");

            migrationBuilder.DropTable(
                name: "CustomerDemographics");

            migrationBuilder.DropTable(
                name: "Territories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
