using Layout_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Layout_Assignment.ViewComponents
{
    public class WeatherViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CityWeather cityWeather)
        {

            return View(cityWeather);
        }
    }
}
