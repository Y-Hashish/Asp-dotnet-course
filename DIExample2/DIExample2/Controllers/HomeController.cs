using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DIExample2.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICitiesService _citiesService;
        public HomeController(ICitiesService citiesService)
        {   
            _citiesService = citiesService;
        }

        [Route("/")]
        public IActionResult Index()
        {

            return View(_citiesService.GetCities());
        }
    }
}
