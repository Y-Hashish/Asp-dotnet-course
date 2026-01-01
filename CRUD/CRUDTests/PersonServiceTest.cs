using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace CRUDTests
{
    public class PersonServiceTest
    {

        public readonly IPersonService _person;
        public readonly ICountriesService _country;
        public readonly ITestOutputHelper _testOutputHelper;

        public PersonServiceTest(ITestOutputHelper testOutputHelper)
        {
            _person = new PersonService();
            _country = new CountriesService();
            _testOutputHelper = testOutputHelper;
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

        #region Get Person list 


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
            CountyAddRequest country_request_1 = new CountyAddRequest() { CountryName = "USA" };
            CountyAddRequest country_request_2 = new CountyAddRequest() { CountryName = "India" };

            CountryResponse country_response_1 = _country.AddCountry(country_request_1);
            CountryResponse country_response_2 = _country.AddCountry(country_request_2);

            PersonAddRequest person_request_1 = new PersonAddRequest() { PersonName = "Smith", Email = "smith@example.com", Gender = GenderOptions.Male, Address = "address of smith", CountryID = country_response_1.Id, DateOfBirth = DateTime.Parse("2002-05-06"), ReceiveNewsLetters = true };

            PersonAddRequest person_request_2 = new PersonAddRequest() { PersonName = "Mary", Email = "mary@example.com", Gender = GenderOptions.Female, Address = "address of mary", CountryID = country_response_2.Id, DateOfBirth = DateTime.Parse("2000-02-02"), ReceiveNewsLetters = false };

            PersonAddRequest person_request_3 = new PersonAddRequest() { PersonName = "Rahman", Email = "rahman@example.com", Gender = GenderOptions.Male, Address = "address of rahman", CountryID = country_response_2.Id, DateOfBirth = DateTime.Parse("1999-03-03"), ReceiveNewsLetters = true };

            List<PersonAddRequest> person_requests = new List<PersonAddRequest>() { person_request_1, person_request_2, person_request_3 };

            List<PersonResponse> person_response_list_from_add = new List<PersonResponse>();

            foreach (PersonAddRequest person_request in person_requests)
            {
                PersonResponse person_response = _person.AddPerson(person_request);
                person_response_list_from_add.Add(person_response);
            }

            //print person_response_list_from_add
            _testOutputHelper.WriteLine("Expected:");
            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }

            //Act
            List<PersonResponse> persons_list_from_get = _person.GetPersonList();

            //print persons_list_from_get
            _testOutputHelper.WriteLine("Actual:");
            foreach (PersonResponse person_response_from_get in persons_list_from_get)
            {
                _testOutputHelper.WriteLine(person_response_from_get.ToString());
            }

            //Assert
            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                Assert.Contains(person_response_from_add, persons_list_from_get);
            }
        }
        #endregion

        #region get filtered person list 


        [Fact] // test the empty search text
        public void GetFilteredPerson_EmptySearchText()
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
            foreach (var item in personAddRequests)
            {
                personResponses.Add(_person.AddPerson(item));
            }
            List<PersonResponse> personResponses_from_getPersonList =
                _person.GetFilteredPersons(nameof(Person.PersonName), "");

            _testOutputHelper.WriteLine("Expected");
            foreach (var item in personResponses)
            {
                _testOutputHelper.WriteLine(item.ToString());
            }

            _testOutputHelper.WriteLine("Actual");
            foreach (var item in personResponses_from_getPersonList)
            {
                _testOutputHelper.WriteLine(item.ToString());
            }


            //assert 
            foreach (var item in personResponses)
            {
                Assert.Contains(item, personResponses_from_getPersonList);
            }
        }


        [Fact] // add few  persons and search based on person name with some search string and
        // it should match 
        public void GetFilteredPerson_SearchByPersonName()
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
                    PersonName = "yosuefha",
                    Email = "email@sample.com",
                    Address = "address",
                    CountryID = countryResponse.Id,
                    DateOfBirth = DateTime.Parse("2000-01-01"),
                    Gender = GenderOptions.Male,
                    ReceiveNewsLetters = false
                },
                new PersonAddRequest()
                {
                    PersonName = "Hashish",
                    Email = "email@sample.com",
                    Address = "address",
                    CountryID = countryResponse.Id,
                    DateOfBirth = DateTime.Parse("2000-01-01"),
                    Gender = GenderOptions.Male,
                    ReceiveNewsLetters = false
                }
            };
            List<PersonResponse> personResponses = new List<PersonResponse>();
            foreach (var item in personAddRequests)
            {
                personResponses.Add(_person.AddPerson(item));
            }
            List<PersonResponse> personResponses_from_getPersonList =
                _person.GetFilteredPersons(nameof(Person.PersonName), "ha");

            _testOutputHelper.WriteLine("Expected");
            foreach (var item in personResponses)
            {
                _testOutputHelper.WriteLine(item.ToString());
            }

            _testOutputHelper.WriteLine("Actual");
            foreach (var item in personResponses_from_getPersonList)
            {
                _testOutputHelper.WriteLine(item.ToString());
            }


            //assert 
            foreach (var item in personResponses)
            {
                if (item.PersonName != null)
                {

                    if (item.PersonName.Contains("ha", StringComparison.OrdinalIgnoreCase))
                        Assert.Contains(item, personResponses_from_getPersonList);
                }
            }
        }


        #endregion


    }
}
