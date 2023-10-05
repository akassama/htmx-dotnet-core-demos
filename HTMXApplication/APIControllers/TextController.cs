using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HTMXApplication.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        [HttpGet("get-message/{newMessage}")]
        public IActionResult GetNewMessage(string newMessage) 
        {
            newMessage = $@"<div class='alert alert-primary'>
                                <p>Your message is : <strong>{newMessage}</strong></p>
                            </div>"; 
            return Ok(newMessage);
        }

        [HttpGet("set-message")]
        public IActionResult SetNewMessage() 
        {
            var random = new Random();
            int number = random.Next(0, 19);
            string[] carManufacturers = {
                                            "Toyota",
                                            "Honda",
                                            "Ford",
                                            "Chevrolet",
                                            "Volkswagen",
                                            "Nissan",
                                            "Hyundai",
                                            "BMW",
                                            "Mercedes-Benz",
                                            "Audi",
                                            "Subaru",
                                            "Mazda",
                                            "Kia",
                                            "Lexus",
                                            "Jeep",
                                            "Tesla",
                                            "Volvo",
                                            "Porsche",
                                            "Ferrari",
                                            "Lamborghini"
                                        };

            string newMessage = carManufacturers[number];
            newMessage = $@"<div class='alert alert-success'>
                                <strong>{newMessage}</strong>.
                            </div>";
            return Ok(newMessage);
            //Or return Content(newMessage);
        }

    }
}
