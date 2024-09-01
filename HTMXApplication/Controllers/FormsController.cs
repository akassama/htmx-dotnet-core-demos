using HTMXApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HTMXApplication.Controllers
{
    public class FormsController : Controller
    {
        private readonly DataConnection _dataConnection;
        public FormsController(DataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }

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

        [HttpGet("forms/table")]
        public IActionResult FormTable()
        {
            return View();
        }

        [HttpPost("forms/table")]
        public IActionResult AddUser(UsersModel user)
        {
            if (ModelState.IsValid) 
            {
                if (user.UserID == Guid.Empty)
                {
                    user.UserID = Guid.NewGuid();   
                    _dataConnection.Add(user);
                    _dataConnection.SaveChanges();
                }
                else
                {
                    _dataConnection.Update(user);
                    _dataConnection.SaveChanges();
                }

                return RedirectToAction("table", "forms");   
            }

            return View(user);
        }

        [HttpGet("forms/new-user")]
        public IActionResult NewUserForm()
        {
            return View();
        }

        [HttpPost("forms/new-user")]
        public IActionResult NewUserForm(UsersModel user)
        {
            if (ModelState.IsValid)
            {
                user.UserID = Guid.NewGuid();
                _dataConnection.Add(user);
                _dataConnection.SaveChanges();

                return RedirectToAction("table", "forms");
            }

            var errorMessage = "";

            foreach (var item in ModelState.Values)
            {
                foreach (var modelError in item.Errors)
                {
                    errorMessage += "\n" + "Error: " + modelError.ErrorMessage;
                }
            }

            TempData["ErrorMsg"] = errorMessage;

            return View(user);
        }
    }
}
