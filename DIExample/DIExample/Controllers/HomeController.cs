using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _cities;
        public HomeController(ICitiesService cities)
        {
            _cities = cities;
        }
        [Route("/")]
        public IActionResult Index()
        {
            return View(_cities.GetCities());
        }
    }
}
