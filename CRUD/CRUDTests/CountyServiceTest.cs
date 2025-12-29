using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDTests
{
    public class CountyServiceTest
    {
        private readonly ICountriesService _countriesService;

        public CountyServiceTest()
        {
            _countriesService = new CountriesService();
        }

        #region add country 
        // when county add request is null == argument null
        [Fact]
        public void CountyAdd_NullCounty()
        {
            // Arrange
            CountyAddRequest? request = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act 
                _countriesService.AddCountry(request);

            });
        }

        // when county name is null == argument exception 
        [Fact]
        public void CountyAdd_NullCountyName()
        {
            // Arrange
            CountyAddRequest? request = new CountyAddRequest()
            {
                CountryName = null,
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act 
                _countriesService.AddCountry(request);

            });
        }

        // when the county name is duplicate == argyument exception 
        [Fact]
        public void CountyAdd_DuplicateCounty()
        {
            // Arrange
            CountyAddRequest? request1 = new CountyAddRequest()
            {
                CountryName = "usa"
            };
            CountyAddRequest? request2 = new CountyAddRequest()
            {
                CountryName = "usa"
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act 
                _countriesService.AddCountry(request1);
                _countriesService.AddCountry(request2);

            });
        }

        //it should add county name it it meet the roles 
        [Fact]
        public void CountyAdd_AddSuccess()
        {
            // Arrange
            CountyAddRequest? request = new CountyAddRequest()
            {
                CountryName = "nigga"
            };

            // Act
            CountryResponse response = _countriesService.AddCountry(request);
            List<CountryResponse> expected = _countriesService.GetCountryList();
            // Assert 
            Assert.Contains(response, expected);
            Assert.True(response.Id != Guid.Empty);
        }

        #endregion
        #region Get all countries 
        [Fact]
        public void GetCountries_EmptyList()
        {
            //Acts 
            List<CountryResponse> countries = _countriesService.GetCountryList();

            //Asserts 
            Assert.Empty(countries);
        }

        [Fact]
        public void GetCountry_AddedCountries()
        {
            //Arrang
            List<CountyAddRequest> addedCountries = new List<CountyAddRequest>()
            {
                new CountyAddRequest()
                {
                    CountryName="Egypt"
                },
                new CountyAddRequest()
                {
                    CountryName = "Japan"
                }
            };
            //acts
            List<CountryResponse> expectedCountires = new List<CountryResponse>();
            foreach (var country in addedCountries)
            {
                expectedCountires.Add(_countriesService.AddCountry(country));
            }
            List<CountryResponse> actualCountries = _countriesService.GetCountryList();

            foreach (var countries in expectedCountires)
            {
                //Assert
                Assert.Contains(countries, actualCountries);
            }
        }
        #endregion
        #region get country by id 

        [Fact]
        public void getCountryByCountryId_nullCountryId()
        {
            //Arrange
            Guid? countryId= null;

            //Act  
            CountryResponse? countryResponse_from_get_Country_By_Id =
                _countriesService.GetCountry(countryId);
            //Assert
            Assert.Null(countryResponse_from_get_Country_By_Id);

        }

        [Fact]
        public void getCountryByCountryId_ValidCountryId()
        {
            //Arrange
            CountyAddRequest addCountry = new CountyAddRequest()
            {
                CountryName = "The Man"
            };
            CountryResponse? getCountryResponse = 
                _countriesService.AddCountry(addCountry);

            //Act
            CountryResponse? response_from_Get_Valid_CountryId = _countriesService.
                GetCountry(getCountryResponse.Id);

            //Assert

            Assert.Equal(getCountryResponse, response_from_Get_Valid_CountryId);
        }

        #endregion
    }
}
