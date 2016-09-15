using Microsoft.AspNetCore.Mvc;

namespace Angular2MultiSPA.Controllers
{
    /// <summary>
    /// Partial controller - delivers CSHTML partial views, for angular
    /// </summary>
    public class PartialController : Controller
    {
        public IActionResult AppComponent() => PartialView();
    }
}
