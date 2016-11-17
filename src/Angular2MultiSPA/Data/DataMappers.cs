using Angular2MultiSPA.Models;
using Angular2MultiSPA.ViewModels;
using GenFu;
using System;

namespace Angular2MultiSPA.Data
{
    /// <summary>
    /// Application specific data mapping
    /// </summary>
    /// <remarks>
    /// In a real world app you'd likely use Jimmy Bogard's AutoMapper, depending onyour data layer,
    /// rather than these specific repetitive mapping methods.
    /// </remarks>
    public static class DataMappers
    {
        /// <summary>
        /// Map Northwind 'Categories' object into our Category view model
        /// </summary>
        /// <param name="categories">Northwind 'Categories' object</param>
        /// <returns>a Category view model object</returns>
        public static Category MapCategoriesToCategory(this Categories categories)
        {
            return categories == null ? null as Category : new Category
            {
                Id = categories.CategoryId,
                Name = categories.CategoryName,
                Description = categories.Description,
                Image = categories.Picture.ConvertToBase64()
            };
        }

        /// <summary>
        /// Map Northwind 'Employees' object into our Employee view model
        /// </summary>
        /// <param name="employees">Northwind 'Employees' object</param>
        /// <returns>an Employee view model object</returns>
        public static Employee MapEmployeesToEmployee(this Employees employees)
        {
            return employees == null ? null as Employee : new Employee
            {
                Id = employees.EmployeeId,
                FirstName = employees.FirstName,
                LastName = employees.LastName,
                Image = employees.Photo.ConvertToBase64()
            };
        }

        public static Order MapOrdersToOrder(this Orders originalOrder)
        {
            return new Order();
        }

        public static OrderDetail MapOrderDetailsToOrderDetail(this OrderDetails originalOrderDetails)
        {
            return new OrderDetail();
        }

        public static Customer MapCustomersToCustomer(this Customers originalCustomer)
        {
            return originalCustomer == null ? null as Customer : new Customer
            {
                Id = originalCustomer.CustomerId,
                ContactName = originalCustomer.ContactName
            };
        }

        public static Product MapProductsToProduct(this Products originalProduct)
        {
            if (originalProduct == null) return null as Product;

            Product product = new Product
            {
                Id = originalProduct.ProductId,
                CategoryId = originalProduct.CategoryId,
                Name = originalProduct.ProductName,
                Description = GenFu.ValueGenerators.Lorem.Lorem.GenerateSentences(2),
                UnitPrice = originalProduct.UnitPrice,
                QuantityPerUnit = originalProduct.QuantityPerUnit,
                ReorderLevel = originalProduct.ReorderLevel,
                UnitsInStock = originalProduct.UnitsInStock,
                UnitsOnOrder = originalProduct.UnitsOnOrder,
                Discontinued = originalProduct.Discontinued
            };

            return product;
        }

        /// <summary>
        /// Convert images from byte array used MS Access/Northwind to a Base64 string, to allow easy display
        /// </summary>
        /// <param name="originalImage">image as a byte array, with offset</param>
        /// <returns>image base 64 encoded string</returns>
        public static string ConvertToBase64(this byte[] originalImage)
        {
            int offset = 78;
            return Convert.ToBase64String(originalImage, offset, originalImage.Length - offset);
        }
    }
}
