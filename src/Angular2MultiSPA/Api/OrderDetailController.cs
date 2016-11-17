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
    public class OrderDetailController : BaseController
    {
        public OrderDetailController(NorthwindContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {
        }

        /// <summary>
        /// Returns order details within a given order
        /// </summary>
        /// <example>
        /// GET api/orderdetail/1
        /// </example>
        /// <param name="id">id of the order to return</param>
        /// <returns>an Order view model object</returns>
        [HttpGet("{id}")]
        public async Task<IEnumerable<OrderDetail>> Get(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return null;
            }

            var orderDetails = _context.OrderDetails
                                       .Where(a => a.OrderId == id)
                                       .Select(a => a.MapOrderDetailsToOrderDetail());

            return orderDetails;
        }

        /// <summary>
        /// Returns all 'OrderDetails' objects from the database mapped into 'OrderDetail' view model objects
        /// </summary>
        /// <example>
        /// GET api/orderdetail 
        /// </example>
        /// <returns>Order Detail view model objects</returns>
        [HttpGet]
        public async Task<IEnumerable<OrderDetail>> Get()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return null;
            }

            var orderDetails = _context.OrderDetails.Select(a => a.MapOrderDetailsToOrderDetail());

            return orderDetails;
        }

        // POST api/orderdetail
        [Route("api/[controller]")]
        [HttpPost]
        public void Post([FromBody]OrderDetail orderDetail)
        {
            // TODO 
        }

        // PUT api/orderdetail/5
        [Route("api/[controller]")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]OrderDetail orderDetail)
        {
            // TODO 
        }

        // DELETE api/orderdetail/5
        [Route("api/[controller]")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // TODO 
        }
    }
}
