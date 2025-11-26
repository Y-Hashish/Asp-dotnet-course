using Microsoft.AspNetCore.Mvc;
using ViewComponentExample.Models;

namespace ViewComponentExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            PersonGrid personGrid = new PersonGrid()
            {
                GridTitle = "niggas",
                People = new List<Person>()
                {
                    new Person {Name ="nigga 1" ,Job="robbery"},
                    new Person {Name ="nigga 2" ,Job="robbery2"},
                    new Person {Name ="nigga 3" ,Job="robbery3"},
                }
            };
            return View(personGrid);
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("invoke-list")]
        public IActionResult ViewComponentInvoke()
        {
            PersonGrid personGrid = new PersonGrid()
            {
                GridTitle = "niggas",
                People = new List<Person>()
                {
                    new Person {Name ="nigga 1" ,Job="robbery"},
                    new Person {Name ="nigga 2" ,Job="robbery2"},
                    new Person {Name ="nigga 3" ,Job="robbery3"},
                }
            };  
            return ViewComponent("Grid", personGrid);
        }
    }
}
