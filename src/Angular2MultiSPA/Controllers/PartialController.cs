using Microsoft.AspNetCore.Mvc;

namespace Angular2MultiSPA.Controllers
{
    /// <summary>
    /// Deliver CSHTML partial views, used as Angular 2 templates
    /// </summary>
    public class PartialController : Controller
    {
        public IActionResult AppComponent() => PartialView();

        public IActionResult AboutComponent() => PartialView();

        public IActionResult DocumentationComponent() => PartialView();

        public IActionResult ContentComponent() => PartialView();

        public IActionResult EmployeeComponent() => PartialView();

        public IActionResult HomeComponent() => PartialView();

        public IActionResult LoginComponent() => PartialView();

        public IActionResult SignupComponent() => PartialView();
    }
}
