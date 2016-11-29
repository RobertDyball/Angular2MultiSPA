using System.ComponentModel.DataAnnotations;

namespace Angular2MultiSPA.ViewModels
{
    public class Customer
    {
        public string Id { get; set; }

        public string ContactName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        public string Country { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Fax { get; set; }
    }
}
