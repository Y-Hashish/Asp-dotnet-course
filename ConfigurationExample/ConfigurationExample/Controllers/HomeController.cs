using Microsoft.AspNetCore.Mvc;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.config = _configuration["myKey"];
            //ViewBag.config2 = _configuration.GetValue<string>("myKey");
            //ViewBag.config3 = _configuration.GetValue("myKedddy","nigga");

            //reading data from hierarchical Configuration 
            ViewBag.configg = _configuration["person:name"];
            ViewBag.config = _configuration.GetSection("person")["age"];

            IConfigurationSection section = _configuration.GetSection("person");
            ViewBag.configgg = section["name"];
            //or 


            return View();
        }
    }
}
