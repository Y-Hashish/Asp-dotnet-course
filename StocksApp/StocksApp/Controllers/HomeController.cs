using Microsoft.AspNetCore.Mvc;
using StocksApp.Models;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFinnHub _connect;
        private readonly IConfiguration _config;

        public HomeController(IFinnHub connect, IConfiguration config)
        {
            _connect = connect;
            _config = config;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string,object> data =await _connect.GetData(_config["stocktype"]);
            Stock stock = new Stock()
            {
                StockSympol = _config["stocktype"],
                CurrentPrice = Convert.ToDouble( data["c"].ToString()) ,
                lowestPrice = Convert.ToDouble( data["l"].ToString()) ,
                highestPrice = Convert.ToDouble( data["h"].ToString()) ,
                openPrice = Convert.ToDouble( data["o"].ToString()) ,
            };
            return View(stock);
        }
    }
}
