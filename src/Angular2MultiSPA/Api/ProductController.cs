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

    public class ProductController : BaseController
    {
        public ProductController(NorthwindContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {
        }

        /// <summary>
        /// Returns one or more 'Products' objects from the database mapped into a 'Product' view model object
        /// </summary>
        /// <example>
        /// GET api/category/5/1
        /// </example>
        /// <param name="id">id of the record to return</param>
        /// <returns>a Category view model object</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IEnumerable<Product>> Get(int id)
        {
            var products = _context.Products.Where(a => a.CategoryId.HasValue && a.CategoryId.Value == id)
                                   .Select(a => a.MapProductsToProduct()).ToList();
            return products;
        }

        /// <summary>
        /// Returns all 'Products' objects from the database mapped into 'Product' view model objects
        /// </summary>
        /// <example>
        /// GET api/product 
        /// </example>
        /// <returns>Product view model objects</returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var products = _context.Products.Select(a => a.MapProductsToProduct());

            return products;
        }

        // POST api/values
        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        [HttpPost]
        public void Post([FromBody]Category category)
        {
        }

        // PUT api/values/5
        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Category category)
        {
        }

        // DELETE api/values/5
        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
