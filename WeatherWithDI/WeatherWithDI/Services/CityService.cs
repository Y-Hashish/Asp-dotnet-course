using WeatherWithDI.Models;

namespace WeatherWithDI.Services
{
    public class CityService : ICityService
    {
        private List<CityWeather> _cities;
        public CityService()
        {
            _cities = new List<CityWeather>()
            {
                 new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33 },

                new CityWeather() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60 },

                new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82 }
            };
        }
        
        public CityWeather CityDetails(string code)
        {
            return _cities.FirstOrDefault(c => c.CityUniqueCode == code);
        }

        public List<CityWeather> GetCities()
        {
            return _cities;
        }
    }
}
