using HTMXApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HTMXApplication.APIControllers
{
    public class TableController : Controller
    {
        private readonly DataConnection _dataConnection;
        public TableController(DataConnection dataConnection)
        {
            _dataConnection = dataConnection;

        }

        [HttpGet("htmx-form/load-table")]
        public IActionResult LoadTable(UsersModel userModel)
        {
            return PartialView($"Forms/_TableFormData");
        }

        [HttpPost("htmx-form/add-user")]
        public async Task<IActionResult> AddUser(UsersModel userModel)
        {
            var resultData = string.Empty;

            if (ModelState.IsValid)
            {
                userModel.UserID = Guid.NewGuid();
                _dataConnection.Add(userModel);
                _dataConnection.SaveChanges();
            }

            var newData = _dataConnection.Users.Where(x => !x.DeleteStatus).OrderByDescending(o => o.CreatedAt).ToList();

            //string resultData = @$"<tr>
            //                            <td>
            //                                <input type='text' class='form-control' id='Name' name='Name' placeholder='Enter name' required>
            //                            </td>
            //                            <td>
            //                                <input type='text' class='form-control' id='Email' name='Email' placeholder='Enter email' required>
            //                            </td>
            //                            <td>
            //                                <select class='form-select' id='Gender' name='Gender' required>
            //                                    <option value=''>Select value</option>
            //                                    <option value='F'>Female</option>
            //                                    <option value='M'>Male</option>
            //                                </select>
            //                            </td>
            //                            <td>
            //                                <input type='number' class='form-control' minlength='7' id='PhoneNumber' name='PhoneNumber' placeholder='Enter phone number' required>
            //                            </td>
            //                            <td>
            //                                <input type='date' class='form-control' id='DateOfBirth' name='DateOfBirth' placeholder='Enter d.o.b' required>
            //                            </td>
            //                            <td>
            //                            </td>
            //                        </tr>";


            //foreach (var user in newData) 
            //{
            //    resultData += @$"<tr>
            //                        <td>{user.Name}</td>
            //                        <td>{user.Email}</td>
            //                        <td>{user.Gender}</td>
            //                        <td>{user.PhoneNumber}</td>
            //                        <td>{user.DateOfBirth}</td>
            //                        <td>
            //                            <!-- Add Edit and Delete buttons here if needed -->
            //                        </td>
            //                    </tr>";
            //}

            resultData = AppServices.GetUserPostValidation(userModel);

            resultData += AppServices.GetUsersTableData().ToString();

            return Content(resultData);
        }

        [HttpPost("htmx-form/update-user")]
        public async Task<IActionResult> UpdateUser(UsersModel userModel) 
        {
            var returnData = string.Empty;

            if (ModelState.IsValid && userModel.UserID != Guid.Empty)
            {
                _dataConnection.Update(userModel);
                _dataConnection.SaveChanges();
            }

            var dateOfBirth = userModel.DateOfBirth?.ToString("yyyy-MM-dd");
            returnData += @$"<td>{userModel.Name}</td>
                                <td>{userModel.Email}</td>
                                <td>{userModel.Gender}</td>
                                <td>{userModel.PhoneNumber}</td>
                                <td>{dateOfBirth}</td>
                                <td>
                                    <!-- Add Edit and Delete buttons-->
                                    <button type='button' class='btn btn-success mb-1'
		                                    hx-get='/htmx-form/edit-user/{userModel.UserID}'
		                                    hx-trigger='click'
		                                    hx-target='#tr-{userModel.UserID}'
		                                    hx-swap='innerHTML'>
	                                    Edit
                                    </button>
                                    <button type='button' class='btn btn-danger mb-1'
		                                    hx-post='/htmx-form/remove-user/{userModel.UserID}'
		                                    hx-trigger='click'
		                                    hx-confirm='Are you sure you wish to remove user?'
		                                    hx-target='#tr-{userModel.UserID}'
		                                    hx-swap='innerHTML'>
	                                    Remove
                                    </button>
                                </td>";

            return Content(returnData);

        }

        [HttpGet("htmx-form/edit-user/{userId}")]
        public IActionResult EditUserForm(Guid userId)
        {
            string returnData = string.Empty;

            if (userId != Guid.Empty)
            {
                var record = _dataConnection.Users.Where(u=> u.UserID == userId).FirstOrDefault();
                string femaleSelected = record.Gender == "F" ? "selected" : "";
                string maleSelected = record.Gender == "M" ? "selected" : "";
                string dateEdit = record.DateOfBirth?.ToString("yyyy-MM-dd");
                returnData += @$"<td>
                                    <input type='text' class='form-control' id='Name' name='Name' placeholder='Enter name' value='{record.Name}' required>
                                </td>
                                <td>
                                    <input type='text' class='form-control' id='Email' name='Email' placeholder='Enter email' value='{record.Email}' required>
                                </td>
                                <td>
                                    <select class='form-select' id='Gender' name='Gender' required>
                                        <option value=''>Select value</option>
                                        <option value='F' {femaleSelected}>Female</option>
                                        <option value='M' {maleSelected}>Male</option>
                                    </select>
                                </td>
                                <td>
                                    <input type='number' class='form-control' minlength='7' id='PhoneNumber' name='PhoneNumber' placeholder='Enter phone number' value='{record.PhoneNumber}' required>
                                </td>
                                <td>
                                    <input type='date' class='form-control' id='DateOfBirth' name='DateOfBirth' placeholder='Enter d.o.b' value='{dateEdit}' required>
                                </td>
                                <td>
                                    <input type='hidden' class='sr-only' id='UserID' name='UserID' value='{record.UserID}' required>
                                    <button type='button' class='btn btn-dark mb-1'
                                            hx-post='/htmx-form/update-user'
                                            hx-trigger='click'
                                            hx-target='#tr-{record.UserID}'
                                            hx-swap='innerHTML'>
                                        Update 1
                                    </button>
                                    <button type='button' class='btn btn-warning'
                                            hx-get='/htmx-form/cancel-user-edit/{record.UserID}'
                                            hx-trigger='click'
                                            hx-target='#tr-{record.UserID}'
                                            hx-swap='innerHTML'>
                                        Cancel
                                    </button>
                                </td>";
            }

            return Content(returnData);
        }

        [HttpGet("htmx-form/cancel-user-edit/{userId}")]
        public IActionResult CancelUserEdit(Guid userId)
        {
            string returnData = string.Empty;

            if (userId != Guid.Empty)
            {
                var record = _dataConnection.Users.Where(u => u.UserID == userId).FirstOrDefault();
                var dateOfBirth = record.DateOfBirth?.ToString("yyyy-MM-dd");
                returnData += @$"<td>{record.Name}</td>
                                <td>{record.Email}</td>
                                <td>{record.Gender}</td>
                                <td>{record.PhoneNumber}</td>
                                <td>{dateOfBirth}</td>
                                <td>
                                    <!-- Add Edit and Delete buttons-->
                                    <button type='button' class='btn btn-success mb-1'
		                                    hx-get='/htmx-form/edit-user/{record.UserID}'
		                                    hx-trigger='click'
		                                    hx-target='#tr-{record.UserID}'
		                                    hx-swap='innerHTML'>
	                                    Edit
                                    </button>
                                    <button type='button' class='btn btn-danger mb-1'
		                                    hx-post='/htmx-form/remove-user/{record.UserID}'
		                                    hx-trigger='click'
		                                    hx-confirm='Are you sure you wish to remove user?'
		                                    hx-target='#tr-{record.UserID}'
		                                    hx-swap='innerHTML'>
	                                    Remove
                                    </button>
                                </td>";
            }
            return Content(returnData);
        }

        [HttpGet("htmx-form/remove-user/{userId}")]
        public async Task<IActionResult> RemoveUser(Guid userId)
        {
            if (userId != Guid.Empty)
            {
                var userModel = _dataConnection.Users.Where(x => x.UserID == userId).FirstOrDefault();

                userModel.DeleteStatus = true;
                _dataConnection.Update(userModel);
                _dataConnection.SaveChanges();
            }

            return Ok();
        }

    }
}
