using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Angular2MultiSPA.Data;

namespace Angular2MultiSPA.Migrations
{
    [DbContext(typeof(NorthwindContext))]
    [Migration("20160928041707_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Angular2MultiSPA.Models.Categories", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryID");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("Description")
                        .HasColumnType("ntext");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("image");

                    b.HasKey("CategoryId")
                        .HasName("PK_Categories");

                    b.HasIndex("CategoryName")
                        .HasName("CategoryName");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.CustomerCustomerDemo", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnName("CustomerID")
                        .HasColumnType("nchar(5)");

                    b.Property<string>("CustomerTypeId")
                        .HasColumnName("CustomerTypeID")
                        .HasColumnType("nchar(10)");

                    b.HasKey("CustomerId", "CustomerTypeId")
                        .HasName("PK_CustomerCustomerDemo");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("CustomerCustomerDemo");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.CustomerDemographics", b =>
                {
                    b.Property<string>("CustomerTypeId")
                        .HasColumnName("CustomerTypeID")
                        .HasColumnType("nchar(10)");

                    b.Property<string>("CustomerDesc")
                        .HasColumnType("ntext");

                    b.HasKey("CustomerTypeId")
                        .HasName("PK_CustomerDemographics");

                    b.ToTable("CustomerDemographics");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.Customers", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnName("CustomerID")
                        .HasColumnType("nchar(5)");

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 60);

                    b.Property<string>("City")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("ContactName")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("ContactTitle")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("Country")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("Fax")
                        .HasAnnotation("MaxLength", 24);

                    b.Property<string>("Phone")
                        .HasAnnotation("MaxLength", 24);

                    b.Property<string>("PostalCode")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Region")
                        .HasAnnotation("MaxLength", 15);

                    b.HasKey("CustomerId")
                        .HasName("PK_Customers");

                    b.HasIndex("City")
                        .HasName("City");

                    b.HasIndex("CompanyName")
                        .HasName("CompanyName");

                    b.HasIndex("PostalCode")
                        .HasName("PostalCode");

                    b.HasIndex("Region")
                        .HasName("Region");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.Employees", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmployeeID");

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 60);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("Country")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("Extension")
                        .HasAnnotation("MaxLength", 4);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime");

                    b.Property<string>("HomePhone")
                        .HasAnnotation("MaxLength", 24);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Notes")
                        .HasColumnType("ntext");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("image");

                    b.Property<string>("PhotoPath")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("PostalCode")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Region")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<int?>("ReportsTo");

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("TitleOfCourtesy")
                        .HasAnnotation("MaxLength", 25);

                    b.HasKey("EmployeeId")
                        .HasName("PK_Employees");

                    b.HasIndex("LastName")
                        .HasName("LastName");

                    b.HasIndex("PostalCode")
                        .HasName("PostalCode");

                    b.HasIndex("ReportsTo");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.EmployeeTerritories", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnName("EmployeeID");

                    b.Property<string>("TerritoryId")
                        .HasColumnName("TerritoryID")
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("EmployeeId", "TerritoryId")
                        .HasName("PK_EmployeeTerritories");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TerritoryId");

                    b.ToTable("EmployeeTerritories");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnName("OrderID");

                    b.Property<int>("ProductId")
                        .HasColumnName("ProductID");

                    b.Property<float>("Discount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<short>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<decimal>("UnitPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValueSql("0");

                    b.HasKey("OrderId", "ProductId")
                        .HasName("PK_Order_Details");

                    b.HasIndex("OrderId")
                        .HasName("OrdersOrder_Details");

                    b.HasIndex("ProductId")
                        .HasName("ProductsOrder_Details");

                    b.ToTable("Order Details");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderID");

                    b.Property<string>("CustomerId")
                        .HasColumnName("CustomerID")
                        .HasColumnType("nchar(5)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnName("EmployeeID");

                    b.Property<decimal?>("Freight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("RequiredDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ShipAddress")
                        .HasAnnotation("MaxLength", 60);

                    b.Property<string>("ShipCity")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("ShipCountry")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("ShipName")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("ShipPostalCode")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("ShipRegion")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<int?>("ShipVia");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("datetime");

                    b.HasKey("OrderId")
                        .HasName("PK_Orders");

                    b.HasIndex("CustomerId")
                        .HasName("CustomersOrders");

                    b.HasIndex("EmployeeId")
                        .HasName("EmployeesOrders");

                    b.HasIndex("OrderDate")
                        .HasName("OrderDate");

                    b.HasIndex("ShipPostalCode")
                        .HasName("ShipPostalCode");

                    b.HasIndex("ShipVia")
                        .HasName("ShippersOrders");

                    b.HasIndex("ShippedDate")
                        .HasName("ShippedDate");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductID");

                    b.Property<int?>("CategoryId")
                        .HasColumnName("CategoryID");

                    b.Property<bool>("Discontinued")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("QuantityPerUnit")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<short?>("ReorderLevel")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<int?>("SupplierId")
                        .HasColumnName("SupplierID");

                    b.Property<decimal?>("UnitPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValueSql("0");

                    b.Property<short?>("UnitsInStock")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<short?>("UnitsOnOrder")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.HasKey("ProductId")
                        .HasName("PK_Products");

                    b.HasIndex("CategoryId")
                        .HasName("CategoryID");

                    b.HasIndex("ProductName")
                        .HasName("ProductName");

                    b.HasIndex("SupplierId")
                        .HasName("SuppliersProducts");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .HasColumnName("RegionID");

                    b.Property<string>("RegionDescription")
                        .IsRequired()
                        .HasColumnType("nchar(50)");

                    b.HasKey("RegionId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.Shippers", b =>
                {
                    b.Property<int>("ShipperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ShipperID");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("Phone")
                        .HasAnnotation("MaxLength", 24);

                    b.HasKey("ShipperId")
                        .HasName("PK_Shippers");

                    b.ToTable("Shippers");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.Suppliers", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SupplierID");

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 60);

                    b.Property<string>("City")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("ContactName")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("ContactTitle")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("Country")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("Fax")
                        .HasAnnotation("MaxLength", 24);

                    b.Property<string>("HomePage")
                        .HasColumnType("ntext");

                    b.Property<string>("Phone")
                        .HasAnnotation("MaxLength", 24);

                    b.Property<string>("PostalCode")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Region")
                        .HasAnnotation("MaxLength", 15);

                    b.HasKey("SupplierId")
                        .HasName("PK_Suppliers");

                    b.HasIndex("CompanyName")
                        .HasName("CompanyName");

                    b.HasIndex("PostalCode")
                        .HasName("PostalCode");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.Territories", b =>
                {
                    b.Property<string>("TerritoryId")
                        .HasColumnName("TerritoryID")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<int>("RegionId")
                        .HasColumnName("RegionID");

                    b.Property<string>("TerritoryDescription")
                        .IsRequired()
                        .HasColumnType("nchar(50)");

                    b.HasKey("TerritoryId")
                        .HasName("PK_Territories");

                    b.HasIndex("RegionId");

                    b.ToTable("Territories");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.CustomerCustomerDemo", b =>
                {
                    b.HasOne("Angular2MultiSPA.Models.Customers", "Customer")
                        .WithMany("CustomerCustomerDemo")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Angular2MultiSPA.Models.CustomerDemographics", "CustomerType")
                        .WithMany("CustomerCustomerDemo")
                        .HasForeignKey("CustomerTypeId");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.Employees", b =>
                {
                    b.HasOne("Angular2MultiSPA.Models.Employees", "ReportsToNavigation")
                        .WithMany("InverseReportsToNavigation")
                        .HasForeignKey("ReportsTo")
                        .HasConstraintName("FK_Employees_Employees");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.EmployeeTerritories", b =>
                {
                    b.HasOne("Angular2MultiSPA.Models.Employees", "Employee")
                        .WithMany("EmployeeTerritories")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Angular2MultiSPA.Models.Territories", "Territory")
                        .WithMany("EmployeeTerritories")
                        .HasForeignKey("TerritoryId");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.OrderDetails", b =>
                {
                    b.HasOne("Angular2MultiSPA.Models.Orders", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId");

                    b.HasOne("Angular2MultiSPA.Models.Products", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.Orders", b =>
                {
                    b.HasOne("Angular2MultiSPA.Models.Customers", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Orders_Customers");

                    b.HasOne("Angular2MultiSPA.Models.Employees", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_Orders_Employees");

                    b.HasOne("Angular2MultiSPA.Models.Shippers", "ShipViaNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("ShipVia");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.Products", b =>
                {
                    b.HasOne("Angular2MultiSPA.Models.Categories", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Products_Categories");

                    b.HasOne("Angular2MultiSPA.Models.Suppliers", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("Angular2MultiSPA.Models.Territories", b =>
                {
                    b.HasOne("Angular2MultiSPA.Models.Region", "Region")
                        .WithMany("Territories")
                        .HasForeignKey("RegionId")
                        .HasConstraintName("FK_Territories_Region");
                });
        }
    }
}
