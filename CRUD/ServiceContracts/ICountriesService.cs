using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface ICountriesService
    {
        CountryResponse AddCountry(CountyAddRequest? countyAddRequest);
        List<CountryResponse> GetCountryList();
        CountryResponse GetCountry(Guid? countryId);

    }
}
