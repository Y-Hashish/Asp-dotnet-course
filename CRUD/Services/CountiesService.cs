using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly List<Country> _countries;

        public CountriesService()
        {
            _countries = new List<Country>();
        }

        public CountryResponse AddCountry(CountyAddRequest? countyAddRequest)
        {
            //validations 
            // if country add request is null 
            if(countyAddRequest == null)
                throw new ArgumentNullException(nameof(countyAddRequest));
            // if country name is null
            if(countyAddRequest.CountryName == null)
                throw new ArgumentException(nameof(countyAddRequest.CountryName));
            // if country name is already exsit
            if (_countries.Count(c => c.Name == countyAddRequest.CountryName) > 0)
                throw new ArgumentException("county already exist");
            Country country = countyAddRequest.ToCountry();
            
            country.Id = Guid.NewGuid();
            _countries.Add(country);
            return country.ToCountyResponse();
        }

        public List<CountryResponse> GetCountryList()
        {
            return _countries.Select(c =>c.ToCountyResponse()).ToList();
        }
    }
}
