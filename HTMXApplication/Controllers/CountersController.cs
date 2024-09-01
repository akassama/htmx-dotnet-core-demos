using HTMXApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HTMXApplication.Controllers
{
    public class CountersController : Controller
    {
        public int intTotalCount = 0;
        private readonly DataConnection _dataConnection;
        public CountersController(DataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }

        [HttpGet("forms/counters")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("forms/get-total-user")]
        public IActionResult GetTotalUsers()
        {
            int total = _dataConnection.Users.Count(x=> !x.DeleteStatus);
            string results = $@"<span class='danger' hx-get='/forms/get-total-user'
                                        hx-trigger='load delay:1s'
                                        hx-swap='outerHTML'>
                                        {total}
                                  </span>";
            return Content(results);
        }

        [HttpGet("forms/add-count")]
        public IActionResult AddCount()
        {
            int newCount = intTotalCount++;
            return Content($"<span class='text-dark h1'>{newCount}</span>");
        }

        [HttpGet("forms/reduce-count")]
        public IActionResult ReduceCount()
        {
            int newCount = intTotalCount--;
            return Content($"<span class='text-dark h1'>{newCount}</span>");
        }
    }
}
