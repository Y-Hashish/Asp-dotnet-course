using Microsoft.AspNetCore.Mvc;
using WeatherWithDI.Models;

namespace WeatherWithDI.ViewComponents
{
    public class CityViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CityWeather city)
        {
            return View(city);
        }
    }
}
