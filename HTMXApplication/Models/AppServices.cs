using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace HTMXApplication.Models
{
    public class AppServices
    {
        public static HtmlString GetUsersTableData()
        {

            string resultData = string.Empty;

            using (var _dataConnection = new DataConnection()) 
            {
                var newData = _dataConnection.Users.Where(x => !x.DeleteStatus).OrderByDescending(o => o.CreatedAt).ToList();
                foreach (var user in newData)
                {
                    resultData += @$"<tr>
                                    <td>{user.Name}</td>
                                    <td>{user.Email}</td>
                                    <td>{user.Gender}</td>
                                    <td>{user.PhoneNumber}</td>
                                    <td>{user.DateOfBirth?.ToString("yyyy-MM-dd")}</td>
                                    <td>
                                        <!-- Add Edit and Delete buttons here if needed -->
                                        <button type='button' class='btn btn-success mb-1'
		                                            hx-get='/htmx-form/edit-user/{user.UserID}'
		                                            hx-trigger='click'
		                                            hx-target='#tr-{user.UserID}'
		                                            hx-swap='innerHTML'>
	                                            Edit
                                            </button>
                                            <button type='button' class='btn btn-danger mb-1'
		                                            hx-get='/htmx-form/remove-user/{user.UserID}'
		                                            hx-trigger='click'
		                                            hx-confirm='Are you sure you wish to remove user?'
		                                            hx-target='#tr-@item.UserID'
		                                            hx-swap='innerHTML'>
	                                            Remove
                                            </button>
                                    </td>
                                </tr>";
                }
            }

            return new HtmlString(resultData);
        }

        public static string GetUserPostValidation(UsersModel? userModel = null)
        {
            string nameValidation = string.Empty;
            string emailValidation = string.Empty; 
            string genderValidation = string.Empty;
            string phoneNumberValidation = string.Empty;
            string dateOfBirthValidation = string.Empty;

            //nameValidation = string.IsNullOrEmpty(userModel.Name) ? "<span class='text-danger'>Name is required</span>" : "";
            //emailValidation = string.IsNullOrEmpty(userModel.Email) ? "<span class='text-danger'>Email is required</span>" : "";
            //var validEmail = new EmailAddressAttribute();
            //emailValidation = !string.IsNullOrEmpty(userModel.Email) && !validEmail.IsValid(emailValidation) ? "<span class='text-danger'>Email is not valid</span>" : "";
            //genderValidation = string.IsNullOrEmpty(userModel.Gender) ? "<span class='text-danger'>Gender is required</span>" : "";
            //genderValidation = !string.IsNullOrEmpty(userModel.Gender) && (genderValidation != "F" || genderValidation != "M") ? "<span class='text-danger'>Gender should be 'M' or 'F'</span>" : "";
            //phoneNumberValidation = string.IsNullOrEmpty(userModel.PhoneNumber) ? "<span class='text-danger'>PhoneNumber is required</span>" : "";
            //phoneNumberValidation = !string.IsNullOrEmpty(userModel.PhoneNumber) && !int.TryParse(phoneNumberValidation, out _) ? "<span class='text-danger'>PhoneNumber is not valid.</span>" : "";
            //dateOfBirthValidation = userModel.DateOfBirth == null ? "<span class='text-danger'>DateOfBirth is required</span>" : "";
            //dateOfBirthValidation = userModel.DateOfBirth == null && DateTime.TryParse(dateOfBirthValidation, out _) ? "<span class='text-danger'>DateOfBirth is not valid</span>" : "";

            string returnForm = @$"<tr>
                                        <td>
                                            <input type='text' class='form-control' id='Name' name='Name' placeholder='Enter name' required>
                                            {nameValidation}
                                        </td>
                                        <td>
                                            <input type='text' class='form-control' id='Email' name='Email' placeholder='Enter email' required>
                                            {emailValidation}
                                        </td>
                                        <td>
                                            <select class='form-select' id='Gender' name='Gender' required>
                                                <option value=''>Select value</option>
                                                <option value='F'>Female</option>
                                                <option value='M'>Male</option>
                                            </select>
                                            {genderValidation}
                                        </td>
                                        <td>
                                            <input type='number' class='form-control' minlength='7' id='PhoneNumber' name='PhoneNumber' placeholder='Enter phone number' required>
                                            {phoneNumberValidation}
                                        </td>
                                        <td>
                                            <input type='date' class='form-control' id='DateOfBirth' name='DateOfBirth' placeholder='Enter d.o.b' required>
                                            {dateOfBirthValidation}
                                        </td>
                                        <td>
                                            <button type='button' class='btn btn-dark'
                                                    hx-post='/htmx-form/add-user'
                                                    hx-trigger='click'
                                                    hx-target='#table-data'
                                                    hx-swap='innerHTML'>
                                                Save
                                            </button>
                                        </td>
                                    </tr>";

            return returnForm;
        }
    }
}
