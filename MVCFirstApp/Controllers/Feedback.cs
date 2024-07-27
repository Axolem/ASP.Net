using Microsoft.AspNetCore.Mvc;

namespace MVCFirstApp.Controllers
{
    public class Feedback : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitFeedback(string userName, string userFeedback)
        {
            // Process the request

            // Simaulating the server processing delay
            System.Threading.Thread.Sleep(2000);

            return Json(new { sucess = true, message = $"Saved feedback. {userName} said {userFeedback}!" });
        }
    }
}
