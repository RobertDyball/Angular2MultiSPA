using System;
using System.ComponentModel.DataAnnotations;

namespace Angular2MultiSPA.ViewModels
{
    public class SampleData
    {
        // Represents a custom data type.
        // NOTE: Not implemented
        // [DataType(DataType.Custom)]
        // public string Custom { get; set; }

        // Represents an instant in time, expressed as a date and time of day.
        [DataType(DataType.DateTime)]
        public DateTime DateTimeVar { get; set; }

        // Represents a date value.
        [DataType(DataType.Date)]
        public DateTime DateVar { get; set; }

        // Represents a time value.
        [DataType(DataType.Time)]
        public DateTime TimeVar { get; set; }

        // Represents a continuous time during which an object exists.
        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }

        // Represents a phone number value.
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        // Represents a currency value.
        [DataType(DataType.Currency)]
        public decimal Currency { get; set; }

        // Represents text that is displayed.
        [DataType(DataType.Text)]
        public string Text { get; set; }
        
        // Represents an HTML file.
        [DataType(DataType.Html)]
        public string Html { get; set; }

        // Represents multi-line text.
        [DataType(DataType.MultilineText)]
        public string MultilineText { get; set; }

        // Represents an e-mail address.
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        // Represent a password value.
        [Display(Name = "Password")]
        public string Password { get; set; }

        // Represents a URL value.
        [DataType(DataType.Url)]
        public string Url { get; set; }

        // Represents a URL to an image.
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        // Represents a credit card number.
        [DataType(DataType.CreditCard)]
        public string CreditCard { get; set; }

        // Represents a postal code.
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        // Represents file upload data type.
        // NOTE: not implemented
        // [DataType(DataType.Upload)]
        // public string Upload { get; set; }
    }
}
