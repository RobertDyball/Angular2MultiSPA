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
    [Route("api/[controller]")]
    public class EmployeeController : BaseController
    {
        public EmployeeController(NorthwindContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {
        }

        // GET: api/values
        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return null;
            }

            var employees = _context.Employees.Select(a => a.MapEmployeesToEmployee());
            return employees;
        }

        // GET api/values/5
        [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return null;
            }

            var employee = null as Employee;
            return employee;
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
