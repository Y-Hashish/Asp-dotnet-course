using Microsoft.AspNetCore.Mvc;
using SocialMediaLinks.Services;

namespace SocialMediaLinks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISocial social;

        public HomeController(ISocial social)
        {
            this.social = social;
        }
        [Route("/")]
        public IActionResult Index()
        {

            return View(social.GetSocial());
        }
    }
}
