using Layout_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Layout_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private List<CityWeather> cities = new List<CityWeather>()
        {
            new CityWeather()
            {
                CityUniqueCode = "LDN",
                CityName = "London",
                DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),
                TemperatureFahrenheit = 33
            },
            new CityWeather()
            {
                CityUniqueCode = "NYC",
                CityName = "London",
                DateAndTime = Convert.ToDateTime( "2030-01-01 3:00"),
                TemperatureFahrenheit = 60
            },
            new CityWeather()
            {
                CityUniqueCode = "PAR",
                CityName = "Paris",
                DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),
                TemperatureFahrenheit = 82
            },
        };

        [Route("/")]
        [Route("home")]
        public IActionResult Index()
        {

            return View(cities);
        }


        [Route("details/{cityCode}")]
        public IActionResult Details(string cityCode)
        {
            if(cityCode != null)
            {
                CityWeather cityWeather = cities.FirstOrDefault(c => c.CityUniqueCode == cityCode);
                return View(cityWeather);
            }
            return Content("city code is mandatory");
        }
    }
}
