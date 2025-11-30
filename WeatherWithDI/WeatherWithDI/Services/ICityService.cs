using WeatherWithDI.Models;

namespace WeatherWithDI.Services
{
    public interface ICityService
    {
        List<CityWeather> GetCities();
        CityWeather CityDetails(string code);
    }
}
