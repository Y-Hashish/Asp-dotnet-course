using Microsoft.AspNetCore.Mvc;
using Partial_Views.Models;

namespace Partial_Views.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("home")]
        public IActionResult Index()
        {
            var data = new List<string>()
            {
                "menof",
                "sers",
                "paris",
                "da hood"
            };
            ViewBag.Data = data;
            ViewBag.tt = "Title";
            return View();
        }
        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
        [Route("program")]
        public ActionResult programs()
        {
            var data = new List()
            {
                ListItems =
                {
                    "menof",
                    "sers",
                    "paris",
                    "da hood"
                },
                ListTitle = "hashish city"
            };
            return PartialView("_ListPartialView", data);
        }

        [Route("programming-languages")]
        public IActionResult ProgrammingLanguages()
        {
            List listModel = new List()
            {
                ListTitle = "Programming Languages List",
                ListItems = new List<string>()
                {
                    "Python",
                    "C#",
                    "Go"
                }
            };

            return PartialView("_ListPartialView", listModel);
        }
    }
}
