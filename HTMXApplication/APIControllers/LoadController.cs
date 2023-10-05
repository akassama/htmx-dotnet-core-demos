using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HTMXApplication.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadController : ControllerBase
    {
        [HttpGet("load-image")]
        public IActionResult LoadImage()
        {
            var random = new Random();
            int number = random.Next(0, 9);
            string newImage = $"pexels-{number}.jpg";
            newImage = $@"<img src='/img/hd-bgs/{newImage}' class='img-fluid' alt='Pexel image : {newImage}'> ";
            return Ok(newImage);
        }

        [HttpGet("load-table")]
        public IActionResult LoadTable()
        {
            string table = @$"<table class='text-start datatable table table-bordered w-100'>
                                <thead>
                                    <tr>
                                    <th>Firstname</th>
                                    <th>Lastname</th>
                                    <th>Email</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                    <td>John</td>
                                    <td>Doe</td>
                                    <td>john@example.com</td>
                                    </tr>
                                    <tr>
                                    <td>Mary</td>
                                    <td>Moe</td>
                                    <td>mary@example.com</td>
                                    </tr>
                                    <tr>
                                    <td>July</td>
                                    <td>Dooley</td>
                                    <td>july@example.com</td>
                                    </tr>
                                </tbody>
                             </table>";
            return Ok(table);
        }

        [HttpGet("load-table-data")]
        public IActionResult LoadTableData()
        {
            string table = @$"<tr>
                                <td>John</td>
                                <td>Doe</td>
                                <td>john@example.com</td>
                             </tr>
                             <tr>
                                <td>Mary</td>
                                <td>Moe</td>
                                <td>mary@example.com</td>
                             </tr>
                             <tr>
                                <td>July</td>
                                <td>Dooley</td>
                                <td>july@example.com</td>
                             </tr>";
            return Ok(table);
        }
    }
}
