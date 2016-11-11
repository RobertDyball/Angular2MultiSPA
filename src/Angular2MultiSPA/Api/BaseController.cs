using Angular2MultiSPA.Data;
using Angular2MultiSPA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Angular2MultiSPA.Api
{

    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected NorthwindContext _context;

        public BaseController(NorthwindContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
    }
}
