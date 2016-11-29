using System;
using System.ComponentModel.DataAnnotations;

namespace Angular2MultiSPA.ViewModels
{
    public class Order
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int? ShipVia { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Freight { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }

        [DataType(DataType.PostalCode)]
        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }
    }
}
