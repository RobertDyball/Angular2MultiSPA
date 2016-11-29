using System.ComponentModel.DataAnnotations;

namespace Angular2MultiSPA.ViewModels
{
    public class Product
    {
        public int Id { get; set; }

        /// <summary>
        /// Short name of product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Full description of product
        /// </summary>
        public string Description { get; set; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        /// <summary>
        /// Quantity per unit
        /// </summary>
        public string QuantityPerUnit { get; set; }

        /// <summary>
        /// The unit price of the item, in dollars
        /// </summary>
        [DataType(DataType.Currency)]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        /// <summary>
        /// True if item is discontinued
        /// </summary>
        public bool Discontinued { get; set; }
    }
}
