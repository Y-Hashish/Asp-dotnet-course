using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IConfiguration _configuration;
        private readonly PersonApiOptions _options;
        public HomeController(IOptions<PersonApiOptions> configuration)
        {
            _options = configuration.Value;
        }
        [Route("/")]
        public IActionResult Index()
        {

            //ViewBag.config = _configuration["myKey"];
            //ViewBag.config2 = _configuration.GetValue<string>("myKey");
            //ViewBag.config3 = _configuration.GetValue("myKedddy","nigga");


            //reading data from hierarchical Configuration 
            //ViewBag.configg = _configuration["person:name"];
            //ViewBag.config = _configuration.GetSection("person")["age"];

            //IConfigurationSection section = _configuration.GetSection("person");
            //ViewBag.configgg = section["name"];
            //or 

            // reading the data from the appSetting.json using the class and options pattern

            //PersonApiOptions options = _configuration.GetSection("person").Get<PersonApiOptions>();
            //PersonApiOptions options1 = new PersonApiOptions();
            //_configuration.GetSection("person").Bind(options1);
            //ViewBag.config = options1?.Name;
            //ViewBag.configg  = options1?.Age;


            // use the class as a service after we inject the options above 

            ViewBag.config = _options.Name;
            ViewBag.configg = _options.Age;


            return View();
        }
    }
}
