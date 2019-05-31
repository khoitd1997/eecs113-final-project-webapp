using Microsoft.AspNetCore.Mvc;

namespace eecs113_webapp
{
    public class HomeController : Controller
    {
        [Route("home/index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}