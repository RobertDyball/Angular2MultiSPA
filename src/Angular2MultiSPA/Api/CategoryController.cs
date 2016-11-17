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
    public class CategoryController : BaseController
    {
        public CategoryController(NorthwindContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {
        }

        /// <summary>
        /// Returns a single 'Categories' object from the database mapped into a 'Category' view model object
        /// </summary>
        /// <example>
        /// GET api/category/5 
        /// </example>
        /// <param name="id">id of the record to return</param>
        /// <returns>a Category view model object</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {
            var category = _context.Categories
                                   .DefaultIfEmpty(null as Categories)
                                   .FirstOrDefault(a => a.CategoryId == id)
                                   .MapCategoriesToCategory();

            return category;
        }

        /// <summary>
        /// Returns all 'Categories' objects from the database mapped into 'Category' view model objects
        /// </summary>
        /// <example>
        /// GET api/category 
        /// </example>
        /// <returns>Category view model objects</returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            var categories = _context.Categories.Select(a => a.MapCategoriesToCategory());

            return categories;
        }

        // POST api/category
        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        [HttpPost]
        public void Post([FromBody]Category category)
        {
            // TODO 
        }

        // PUT api/category/5
        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Category category)
        {
            // TODO 
        }

        // DELETE api/category/5
        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // TODO 
        }
    }
}
