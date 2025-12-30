using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDTests
{
    public class PersonServiceTest
    {
        public readonly IPersonService _person;
        public readonly ICountriesService _country;

        public PersonServiceTest()
        {
            _person = new PersonService();
            _country = new CountriesService();
        }
        #region Adding person



        [Fact] // tests when the person add requset is null 
        public void PersonRequestNull()
        {
            //arrange 
            PersonAddRequest? request = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                _person.AddPerson(request);
            });
        }

        [Fact] // tests when the person name is null 
        public void PersonAddRequest_NameNull()
        {
            //arrange 
            PersonAddRequest? request = new PersonAddRequest()
            {
                PersonName = null,
                
            };

            Assert.Throws<ArgumentException>(() =>
            {
                _person.AddPerson(request);
            });
        }

        [Fact] // tests when the person name is null 
        public void PersonAddRequest_Correct()
        {
            //arrange 
            PersonAddRequest? personAddRequest = new PersonAddRequest()
            {
                PersonName = "Person name...",
                Email = "person@example.com",
                Address = "sample address",
                CountryID = Guid.NewGuid(),
                Gender = GenderOptions.Male,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                ReceiveNewsLetters = true
            };

            //acts 
            PersonResponse personResponse = _person.AddPerson(personAddRequest);
            List<PersonResponse> allPerson_from_getPersonList = 
                _person.GetPersonList();

            //Assert 
            Assert.True(personResponse.PersonID != Guid.Empty);
            Assert.Contains(personResponse, allPerson_from_getPersonList);

        }
        #endregion

        #region Get person by id 

        [Fact] // tests if person id is null and if it handled or not 
        public void GetPersonById_NullId()
        {
            //arrange 
            Guid? personId = null;

            //Acts
            PersonResponse personResponse = _person.GetPersonById(personId);
            
            //Assert 
            Assert.Null(personResponse);

        }

        [Fact]// return the right data if the id is correct 
        public void GetPersonById_Details()
        {
            //arrange 
            CountyAddRequest countyAddRequest = new CountyAddRequest()
            {
                CountryName = "Japan"
            };
            CountryResponse countryResponse = _country.AddCountry(countyAddRequest);

            PersonAddRequest personAddRequest = new PersonAddRequest()
            {
                PersonName = "person name...",
                Email = "email@sample.com",
                Address = "address",
                CountryID = countryResponse.Id,
                DateOfBirth = DateTime.Parse("2000-01-01"),
                Gender = GenderOptions.Male,
                ReceiveNewsLetters = false
            };

            //acts 
            PersonResponse? personResponse = _person.AddPerson(personAddRequest);
            PersonResponse? person_from_GetpersonByid = _person.GetPersonById(personResponse.PersonID);

            //assert 
            Assert.Equal(personResponse, person_from_GetpersonByid);
        }

        #endregion

        [Fact] 
        public void GetPersonList_Empty()
        {
            //arrange 
            List<PersonResponse> personList = _person.GetPersonList();

            //assert 
            Assert.Empty(personList);
        }

        [Fact]
        public void GetPersonList_Correct_added_person()
        {
            CountyAddRequest countyAddRequest = new CountyAddRequest()
            {
                CountryName = "Japan"
            };
            CountryResponse countryResponse = _country.AddCountry(countyAddRequest);

            List<PersonAddRequest> personAddRequests = new List<PersonAddRequest>()
            {
                new PersonAddRequest()
                {
                    PersonName = "yosuef",
                    Email = "email@sample.com",
                    Address = "address",
                    CountryID = countryResponse.Id,
                    DateOfBirth = DateTime.Parse("2000-01-01"),
                    Gender = GenderOptions.Male,
                    ReceiveNewsLetters = false
                },
                new PersonAddRequest()
                {
                    PersonName = "hashish",
                    Email = "email@sample.com",
                    Address = "address",
                    CountryID = countryResponse.Id,
                    DateOfBirth = DateTime.Parse("2000-01-01"),
                    Gender = GenderOptions.Male,
                    ReceiveNewsLetters = false
                }
            };
            List<PersonResponse> personResponses = new List<PersonResponse>();
            foreach(var item in personAddRequests)
            {
                personResponses.Add(_person.AddPerson(item));
            }
            List<PersonResponse> personResponses_from_getPersonList =
                _person.GetPersonList();
            //assert 
            foreach(var item in personResponses)
            {
                Assert.Contains(item, personResponses_from_getPersonList);
            }
        }

    }
}
