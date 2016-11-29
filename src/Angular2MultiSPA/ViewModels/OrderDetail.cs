using System.ComponentModel.DataAnnotations;

namespace Angular2MultiSPA.ViewModels
{
    public class OrderDetail
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        /// <summary>
        /// The unit price of the item, in dollars
        /// </summary>
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Quantity ordered
        /// </summary>
        public short Quantity { get; set; }
    }
}
