using Microsoft.AspNetCore.Mvc;
using StocksApp2.Services;

namespace StocksApp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFinnHub _service;

        public HomeController(IFinnHub service)
        {
            _service = service;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string,object> data = await _service.GetData();
            List<double> list = new List<double>()
            {
                Convert.ToDouble(data["c"].ToString()),
                Convert.ToDouble(data["h"].ToString()),
                Convert.ToDouble(data["l"].ToString()),
                Convert.ToDouble(data["o"].ToString()),
            };
            return View(list);
        }
    }
}
