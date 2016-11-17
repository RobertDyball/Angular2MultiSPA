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
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    public class OrderController : BaseController
    {
        public OrderController(NorthwindContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {
        }

        /// <summary>
        /// Returns agiven order
        /// </summary>
        /// <example>
        /// GET api/order/1
        /// </example>
        /// <param name="id">id of the order to return</param>
        /// <returns>an Order view model object</returns>
        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            var order = _context.Orders
                                   .DefaultIfEmpty(null as Orders)
                                   .FirstOrDefault(a => a.OrderId == id)
                                   .MapOrdersToOrder();

            return order;
        }

        /// <summary>
        /// Returns all 'Order' objects from the database mapped into 'Product' view model objects
        /// </summary>
        /// <example>
        /// GET api/order 
        /// </example>
        /// <returns>Order view model objects</returns>
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return null;
            }

            var orders = _context.Orders.Select(a => a.MapOrdersToOrder());

            return orders;
        }

        // POST api/order
        [Route("api/[controller]")]
        [HttpPost]
        public void Post([FromBody]Order order)
        {
            // TODO 
        }

        // PUT api/order/5
        [Route("api/[controller]")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Order order)
        {
            // TODO 
        }

        // DELETE api/order/5
        [Route("api/[controller]")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // TODO 
        }
    }
}
