using Microsoft.AspNetCore.Mvc;
using Views.Models;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            List<Person> people = new List<Person>()
            {
                new Person(){name= "youssef" , dateOfBirth= Convert.ToDateTime("2002-01-02")},
                new Person(){name= "emad" , dateOfBirth= Convert.ToDateTime("2004-01-02")},
                new Person(){name= "hashish" , dateOfBirth= Convert.ToDateTime("2006-01-02")},
            };
            ViewData["title"] = "title from view data";

            return View(people);
        }
        [Route("person-details/{name?}")]
        public IActionResult PersonDetails(string? name)
        {
            if (name == null)
                return Content(" the name is null enter the name please ");
            List<Person> people = new List<Person>()
            {
                new Person(){name= "youssef" , dateOfBirth= Convert.ToDateTime("2002-01-02")},
                new Person(){name= "emad" , dateOfBirth= Convert.ToDateTime("2004-01-02")},
                new Person(){name= "hashish" , dateOfBirth= Convert.ToDateTime("2006-01-02")},
            };
            Person? selected = people.Where(p => p.name == name).FirstOrDefault();
            return View(selected);
        }

        [Route("nigga")]
        public IActionResult All()
        {
            Person person = new Person()
            {
                name = "Test",
                gender = Gender.male,
                dateOfBirth = DateTime.Now,
            };
            return View(person);
        }
    }
}
