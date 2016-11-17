using Angular2MultiSPA.Data;
using Angular2MultiSPA.Models;
using Angular2MultiSPA.ViewModels;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular2MultiSPA.Api
{

    public class CustomerController : BaseController
    {
        public CustomerController(NorthwindContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {
        }

        /// <summary>
        /// Returns a given 'Customers' object from the database mapped into a 'Customer' view model object
        /// </summary>
        /// <example>
        /// GET api/customer/5/1
        /// </example>
        /// <param name="id">id of the record to return</param>
        /// <returns>a Customer view model object</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<Customer> Get(string id)
        {
            var customer = _context.Customers
                                   .DefaultIfEmpty(null as Customers)
                                   .FirstOrDefault(a => a.CustomerId == id);

            return customer.MapCustomersToCustomer();
        }

        /// <summary>
        /// Returns all 'Customers' objects from the database mapped into 'Customer' view model objects
        /// </summary>
        /// <example>
        /// GET api/customer 
        /// </example>
        /// <returns>Customer view model objects</returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            var customer = _context.Customers
                                   .Select(a => a.MapCustomersToCustomer())
                                   .ToList();

            return customer;
        }

        // POST api/customer
        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        [HttpPost]
        public void Post([FromBody]Customer customer)
        {
            // TODO 
        }

        // PUT api/customer/5
        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Customer customer)
        {
            // TODO 
        }

        // DELETE api/customer/5
        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // TODO 
        }
    }
}
