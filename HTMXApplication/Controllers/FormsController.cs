using Microsoft.AspNetCore.Mvc;

namespace HTMXApplication.Controllers
{
    public class FormsController : Controller
    {
        [HttpGet("forms/dynamic-forms")]
        public IActionResult DynamicForms()
        {
            return View();
        }

        [HttpGet("forms/load-forms")]
        public IActionResult LoadForms()
        {
            return View();
        }

        [HttpGet("forms/counters")]
        public IActionResult Counters()
        {
            return View();
        }
    }
}
