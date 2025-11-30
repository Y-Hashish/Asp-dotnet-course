using Microsoft.AspNetCore.Mvc;
using WeatherWithDI.Services;

namespace WeatherWithDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICityService _cityService;
        public HomeController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View(_cityService.GetCities());
        }
        [Route("details/{code}")]
        public IActionResult Details(string code)
        {
            if(code != null)
            {
                return View(_cityService.CityDetails(code));
            }
            return BadRequest("enter a valid code");
        }
    }
}
