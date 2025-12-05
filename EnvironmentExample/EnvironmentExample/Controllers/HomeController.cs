using Microsoft.AspNetCore.Mvc;

namespace EnvironmentExample.Controllers
{
    public class HomeController : Controller
    {

        private readonly IWebHostEnvironment _webHost;
        public HomeController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        [Route("/")]
         public IActionResult Index()
         {
            ViewBag.nigga = _webHost.EnvironmentName;
            return View();
         }
        [Route("nigga")]
        public IActionResult Other()
        {
            return View();
        }
    }
}
