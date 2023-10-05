using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace HTMXApplication.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        [HttpGet("load-form")]
        public IActionResult LoadForm()
        {
            string form = $@"	<form action='#' class='form-validation'>
				  <!-- Text input -->
				  <div class='row mb-4'>
					<div class='col'>
						<label class='form-label' for='form6Example1'>First name</label>
						<input type='text' id='form6Example1'  name='form6Example1' class='form-control' required />
					</div>
					<div class='col'>
						<label class='form-label' for='form6Example2'>Last name</label>
						<input type='text' id='form6Example2' name='form6Example2' class='form-control' required />
					</div>
				  </div>

				  <!-- Select option -->
				  <div class='mb-4'>
					<label class='form-label' for='form6Example3'>Select name</label>
						<select class='form-select' id='form6Example3' name='form6Example3' required>
						  <option value=''>Select value</option>
						  <option value='1'>1</option>
						  <option value='2'>2</option>
						  <option value='3'>3</option>
						</select>
				  </div>

				  <!-- Text input -->
				  <div class='mb-4'>
					<label class='form-label' for='form6Example4'>Address</label>
					<input type='text' id='form6Example4' name='form6Example4' class='form-control' required />
				  </div>

				  <!-- Email input -->
				  <div class='mb-4'>
					<label class='form-label' for='form6Example5'>Email</label>
					<input type='email' id='form6Example5' name='form6Example5' class='form-control' required />
				  </div>

				  <!-- Number input -->
				  <div class='mb-4'>
					<label class='form-label' for='form6Example6'>Phone</label>
					<input type='number' id='form6Example6' name='form6Example6' class='form-control' required />
				  </div>

				  <!-- Message input -->
				  <div class='mb-4'>
					<label class='form-label' for='form6Example7'>Additional information</label>
					<textarea class='form-control' id='form6Example7' name='form6Example7' rows='4' required></textarea>
				  </div>

				  <!-- Checkbox -->
				  <div class='d-flex justify-content-center mb-4'>
					<label class='form-check-label' for='form6Example8'> Create an account? </label>
					<input class='form-check-input me-2' type='checkbox' value='' id='form6Example8' name='form6Example8' required />
				  </div>

				  <!-- Submit button -->
				  <button type='submit' class='btn btn-primary btn-block mb-4'>Submit</button>
				</form>";
            return Ok(form);
        }

        [HttpGet("load-bs-form")]
        public IActionResult LoadBSForm()
        {
            string table = @$"	<form class='row g-3 needs-validation' novalidate>
							  <div class='col-md-4'>
								<label for='validationCustom01' class='form-label'>First name</label>
								<input type='text' class='form-control' id='validationCustom01' value='Mark' required>
								<div class='valid-feedback'>
								  Looks good!
								</div>
								<div class='invalid-feedback'>
									Please choose a first name.
								</div>
							  </div>
							  <div class='col-md-4'>
								<label for='validationCustom02' class='form-label'>Last name</label>
								<input type='text' class='form-control' id='validationCustom02' required>
								  <div class='invalid-feedback'>
									Please choose a last name.
								  </div>
							  </div>
							  <div class='col-md-4'>
								<label for='validationCustomUsername' class='form-label'>Username</label>
								<div class='input-group has-validation'>
								  <span class='input-group-text' id='inputGroupPrepend'>@</span>
								  <input type='text' class='form-control' id='validationCustomUsername' aria-describedby='inputGroupPrepend' required>
								  <div class='invalid-feedback'>
									Please choose a username.
								  </div>
								</div>
							  </div>
							  <div class='col-md-6'>
								<label for='validationCustom03' class='form-label'>City</label>
								<input type='text' class='form-control' id='validationCustom03' required>
								<div class='invalid-feedback'>
								  Please provide a valid city.
								</div>
							  </div>
							  <div class='col-md-3'>
								<label for='validationCustom04' class='form-label'>State</label>
								<select class='form-select' id='validationCustom04' required>
								  <option selected disabled value=''>Choose...</option>
								  <option>...</option>
								</select>
								<div class='invalid-feedback'>
								  Please select a valid state.
								</div>
							  </div>
							  <div class='col-md-3'>
								<label for='validationCustom05' class='form-label'>Zip</label>
								<input type='text' class='form-control' id='validationCustom05' required>
								<div class='invalid-feedback'>
								  Please provide a valid zip.
								</div>
							  </div>
							  <div class='col-12'>
								<div class='form-check'>
								  <input class='form-check-input' type='checkbox' value='' id='invalidCheck' required>
								  <label class='form-check-label' for='invalidCheck'>
									Agree to terms and conditions
								  </label>
								  <div class='invalid-feedback'>
									You must agree before submitting.
								  </div>
								</div>
							  </div>
							  <div class='col-12'>
								<button class='btn btn-primary' type='submit'>Submit form</button>
							  </div>
							</form>";
            return Ok(table);
        }

        [HttpGet("get-form-element/{elementType}/{elementName}/{displayName}/{value?}/{required?}/{customClass?}")]
        public IActionResult GetFormElement(string elementType, string elementName, string displayName, string value = "", string required = "", string customClass = "")
        {
            string elementInput = string.Empty;

            switch (elementType.ToLower())
            {
                case "input":
                    elementInput = $@"<div class='mb-3'>
										<label class='form-label' for='{elementName}'>{displayName}</label>
										<input type='text' class='form-control {customClass}' id='{elementName}' name='{elementName}' value='{value}' {required}>
								  </div>";
                    break;
                case "email":
                    elementInput = $@"<div class='mb-3'>
										<label class='form-label' for='{elementName}'>{displayName}</label>
										<input type='email' class='form-control {customClass}' id='{elementName}' name='{elementName}' value='{value}' {required}>
								  </div>";
                    break;
                case "textarea":
                    elementInput = $@"<div class='mb-3'>
											<label class='form-label' for='{elementName}'>{displayName}</label>
											<textarea class='form-control {customClass}' id='{elementName}' name='{elementName}' {required}>{value}</textarea>
										</div>";
                    break;
                case "checkbox":
                    elementInput = $@"<div class='mb-3'>
									   <div class='form-check'>
										  <input type='checkbox' class='form-check-input {customClass}' id='{elementName}' name='{elementName}' value='{value}' {required}>
										  <label class='form-check-label' for='{elementName}'>{displayName}</label>
									   </div>
									</div>";
                    break;
                case "radio":
                    elementInput = $@"<div class='mb-3'>
									   <div class='form-check'>
										  <input type='radio' class='form-check-input {customClass}' id='{elementName}' name='{elementName}' value='{value}' {required}>
										  <label class='form-check-label' for='{elementName}'>{displayName}</label>
									   </div>
									</div>";
                    break;
                case "selectoption":
                    elementInput = $@"<div class='mb-3'>
										<label class='form-label' for='{elementName}'>{displayName}</label>
										<select class='form-select {customClass}' id='{elementName}' name='{elementName}'>
										  <option value=''>Select order</option>
										  <option value='1'>1</option>
										  <option value='2'>2</option>
										  <option value='3'>3</option>
										</select>
								  </div>";
                    break;
                case "button":
                    elementInput = $@"<button type='submit' name='{elementName}' id='{elementName}' class='btn btn-primary mt-3'>{displayName}</button>";
                    break;
                default:
                    break;
            }

            return Ok(elementInput);
        }

        [HttpPost("set-other-input")]
        public IActionResult SetOtherInput() 
        {
			string GetOtherInput = (string)HttpContext.Request.Form["GetOtherInput"] ?? "";

            string input = "";

            if (GetOtherInput.ToLower() == "true")
            {
                input = $@"<div class='mb-3'>
							<label class='form-label' for='Email'>Provide Email</label>
							<input type='email' class='form-control' id='Email' name='Email' value='' required>
						</div>";
            }
            return Ok(input);
        }

        [HttpPost("set-gender-details")]
        public IActionResult SetGenderDetails() 
        {
			string selectedGender = (string)HttpContext.Request.Form["gender"] ?? "";

            string input = "";

            if (selectedGender.ToLower() == "f")
            {
                input = $@"
						<div class='mb-3'>
							<label class='form-label' for='number-of-children'>Are you a mother?</label>
							<input type='checkbox' class='form-check-input' id='number-of-children-check' name='number-of-children-check' value='true'
									hx-post='/api/form/set-number-of-children'
									hx-trigger='click'
									hx-target='#number-of-children-element'
									hx-swap='innerHTML'>
						</div>
						<div id='number-of-children-element'>
							<!--For selecting female-->
						</div>";
            }
			else if (selectedGender.ToLower() == "m")
            {
                input = $@"
						<div class='mb-3'>
							<label class='form-label' for='military-service'>Have you served in the military?</label>
							<input type='checkbox' class='form-check-input' id='military-service-check' name='military-service-check' value='true'
									hx-post='/api/form/set-number-of-years'
									hx-trigger='click'
									hx-target='#number-of-years-element'
									hx-swap='innerHTML'>
						</div>
						<div id='number-of-years-element'>
							<!--For selecting male-->
						</div>";
            }
            return Ok(input);
        }

        [HttpPost("set-number-of-children")]
        public IActionResult SetNumberOfChildren()
        {
            string checkAnswer = (string)HttpContext.Request.Form["number-of-children-check"] ?? "";

            string input = "";

            if (checkAnswer.ToLower() == "true")
            {
                input = $@"<div class='mb-3'>
							<label class='form-label' for='number-of-children'>Number of Children</label>
							<input type='number' class='form-control' id='number-of-children' name='number-of-children' value='' required>
						</div>";
            }
            return Ok(input);
        }

        [HttpPost("set-number-of-years")]
        public IActionResult SetNumberOfYears()
        {
            string checkAnswer = (string)HttpContext.Request.Form["military-service-check"] ?? "";

            string input = "";

            if (checkAnswer.ToLower() == "true")
            {
                input = $@"<div class='mb-3'>
							<label class='form-label' for='number-of-years'>Number of Years</label>
							<input type='number' class='form-control' id='number-of-years' name='number-of-years' value='' required>
						</div>";
            }
            return Ok(input);
        }


        [HttpPost("set-show-bio")]
        public IActionResult SetShowBio() 
        {
			string selectBio = (string)HttpContext.Request.Form["bio_select"] ?? "";

            string input = "";

            if (selectBio.ToLower() == "yes")
            {
                input = $@"<div class='mb-3'>
							<label class='form-label' for='Biography'>Biography</label>
							<textarea class='form-control' id='Biography' name='Biography' required></textarea>
						</div>";
            }
            return Ok(input);
        }

        [HttpPost("check-continue-answer")]
        public IActionResult CheckContinueAnswer() 
        {
			string answer = (string)HttpContext.Request.Form["continue_form"] ?? "";

            string input = "";

            if (answer.ToLower() == "yes")
            {
                input = $@"<button type='submit' id='Continue' class='btn btn-primary mt-3'>Save</button>";
            }
            return Ok(input);
        }

        [HttpPost("check-for-existing-email")]
        public IActionResult CheckExistingEmail() 
        {
			string userEmail = (string)HttpContext.Request.Form["your_email"] ?? "";

            string[] existingEmails = {
                                        "test@example.com",
                                        "john.doe@example.com",
										"jane.smith@example.com",
										"mark.johnson@example.com",
										"susan.wilson@example.com",
										"robert.miller@example.com",
										"emily.davis@example.com",
										"michael.wang@example.com",
										"laura.harris@example.com",
										"david.jackson@example.com",
										"sarah.thomas@example.com"
									};

            string status = "";

			bool emailExists = existingEmails.Contains(userEmail);

            if (emailExists)
            {
                status = $@"<div class='alert alert-danger'>The email <span class='fw-bold fst-italic'>{userEmail}</span> already exists. Please choose a different email.</div>";
            }

			//if not valid email
			if(userEmail.Length > 5 && !emailExists)
			{
                // Define a regular expression pattern for a valid email address
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                // Use Regex.IsMatch to check if the email matches the pattern
                 ;
                status = Regex.IsMatch(userEmail, pattern) ? "" : $@"<div class='alert alert-danger'>The provided email <span class='fw-bold fst-italic'>{userEmail}</span> is not a valid email. Please choose a different email.</div>";
            }

            return Ok(status);
        }


        [HttpGet("models")]
        public IActionResult GetModels(string make) 
        {
            string models;

            if (make.ToLower() == "audi")
            {
                models = $@"<option value='a1'>A1</option> <option value='a4'>A4</option> <option value='a6X5'>A6</option> ";
            }
            else if (make.ToLower() == "toyota")
            {
                models = $@"<option value='landcruiser'>Landcruiser</option> <option value='takoma'>Takoma</option> <option value='yaris'>Yaris</option> ";
            }
            else
            {
                models = $@"<option value='325i'>325i</option> <option value='325ix'>325ix</option> <option value='X5'>X5</option> ";
            }
            return Ok(models);
        }

    }
}
