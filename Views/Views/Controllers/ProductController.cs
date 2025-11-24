using Microsoft.AspNetCore.Mvc;
using Views.Models;

namespace Views.Controllers
{
    public class ProductController : Controller
    {
        [Route("all")]
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
