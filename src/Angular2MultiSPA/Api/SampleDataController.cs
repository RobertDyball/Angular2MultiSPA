using Angular2MultiSPA.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Angular2MultiSPA.Api
{

    public class SampleDataController : BaseController
    {
        public SampleDataController() : base()
        {
        }

        /// <summary>
        /// Returns a 'SampleData' object
        /// </summary>
        /// <example>
        /// GET api/sampleData
        /// </example>
        /// <returns>a Sample Data object</returns>
        [AllowAnonymous]
        [HttpGet]
        public SampleData Get()
        {
            var sampleData = new SampleData()
            {
                DateTimeVar = DateTime.Now,
                DateVar = DateTime.Now.Date,
                TimeVar = DateTime.Now,
                Duration = DateTime.Now.TimeOfDay,
                PhoneNumber = "02 9876 1234",
                Currency = 123.45M,
                Text = "Sample text. Bonjour 您好 Hello こんにちは Hola",
                Html = "<p>html</p>",
                MultilineText = @"Porttitor sollicitudin eget magna leo tempor nec volutpat. 
Et malesuada viverra lacus rhoncus cum vestibulum habitasse. Faucibus viverra sit dictum magna id consectetur neque.
Feugiat vitae enim vestibulum in ut at.",
                EmailAddress = "someone@example.com",
                Password = "P@55word",
                Url = "www.microsoft.com",
                ImageUrl = "http://mp3gain.sourceforge.net/mp3gainlogosmall.gif",
                CreditCard = "4564 1234 1234 1234",
                PostalCode = "1234"

            };

            return sampleData;
        }
    }
}
