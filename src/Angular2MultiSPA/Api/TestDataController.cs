using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Angular2MultiSPA.Data;
using System.Linq;
using Angular2MultiSPA.ViewModels;
using Angular2MultiSPA.Helpers;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Angular2MultiSPA.Api
{
    [Route("api/[controller]")]
    public class TestDataController : Controller
    {
        private NorthwindContext _context;

        public TestDataController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var categories = _context.Categories.Select(a => new Category
            {
                Id = a.CategoryId,
                Name = a.CategoryName,
                Description = a.Description,
                Image = a.Picture.ConvertToBase64()
            });
            return categories;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
