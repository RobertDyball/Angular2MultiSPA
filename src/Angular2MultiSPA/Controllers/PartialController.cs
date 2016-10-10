using Microsoft.AspNetCore.Mvc;

namespace Angular2MultiSPA.Controllers
{
    /// <summary>
    /// Partial controller - delivers CSHTML partial views, for angular
    /// </summary>
    public class PartialController : Controller
    {
        public IActionResult AppComponent() => PartialView();

        public IActionResult AboutComponent() => PartialView();

        public IActionResult ContentComponent() => PartialView();

        public IActionResult HomeComponent() => PartialView();

        public IActionResult LoginComponent() => PartialView();

        public IActionResult SignupComponent() => PartialView();
    }
}
