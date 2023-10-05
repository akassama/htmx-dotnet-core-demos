using Microsoft.AspNetCore.Mvc;

namespace HTMXApplication.Controllers
{
    public class LoadController : Controller
    {
        [HttpGet("load/load-image")]
        public IActionResult LoadImage()
        {
            return View();
        }

        [HttpGet("load/load-table")]
        public IActionResult LoadTable()
        {
            return View();
        }
    }
}
