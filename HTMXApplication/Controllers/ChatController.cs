using Microsoft.AspNetCore.Mvc;

namespace HTMXApplication.Controllers
{
    public class ChatController : Controller
    {
        [HttpGet("forms/chat")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("forms/open-modal/{modId}")]
        public IActionResult OpenModal(string modId)
        {
			//return PartialView($"Chat/_Modal");

			string modal = $@"<!-- <div id='modal-backdrop-{modId}' class='modal-backdrop fade show' style='display:block;'></div> -->
								<!-- The Modal -->
								<div id='mod-{modId}' class='modal fade show' tabindex='-1' style='display:block;'>
									<div class='modal-dialog'>
										<div class='modal-content'>

											<!-- Modal Header -->
											<div class='modal-header'>
												<h4 class='modal-title'>Modal Heading</h4>
												<button type='button' class='btn-close' 
													hx-get='/forms/close-modal'
													hx-target='#mod-{modId}'
													hx-swap='innerHTML'
													hx-trigger='click'>
												</button>
											</div>

											<!-- Modal body -->
											<div class='modal-body'>
												<p>Modal body text goes here.</p>
											</div>

											<!-- Modal footer -->
											<div class='modal-footer'>
												<button type='button' class='btn btn-danger'
													hx-get='/forms/close-modal'
													hx-target='#mod-{modId}'
													hx-swap='innerHTML'
													hx-trigger='click'>
													Close
												</button>
												<button type='button' class='btn btn-primary'>Save changes</button>
											</div>

										</div>
									</div>
								</div>";

			return Content(modal);
		}

        [HttpGet("forms/close-modal")]
        public IActionResult CloseModal()
		{
			return Ok();
		}
    }
}
