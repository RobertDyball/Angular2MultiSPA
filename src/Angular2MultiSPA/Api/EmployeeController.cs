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
    [Route("api/[controller]")]
    public class EmployeeController : BaseController
    {
        public EmployeeController(NorthwindContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {
        }

        // GET: api/employee
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

        // GET api/employee/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return null;
            }

            var employee = _context.Employees
                                   .DefaultIfEmpty(null as Employees)
                                   .FirstOrDefault(a => a.EmployeeId == id);

            return employee.MapEmployeesToEmployee();
        }

        // POST api/employee
        [HttpPost]
        public void Post([FromBody]Employee employee)
        {
            // TODO 
        }

        // PUT api/employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Employee employee)
        {
            // TODO 
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // TODO 
        }
    }
}
