using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _person;
        private readonly ICountriesService _CountryService;

        public PersonService()
        {
            _CountryService = new CountriesService();
            _person = new List<Person>();
        }
        private PersonResponse Convert (Person person)
        {
            PersonResponse response = person.ToPersonResponse();
            response.Country = _CountryService.GetCountry(person.CountryID)?.Name;
            return response;
        }
        public PersonResponse AddPerson(PersonAddRequest? Person)
        {
            if(Person == null) 
                throw new ArgumentNullException(nameof(Person));


            //if (string.IsNullOrEmpty(Person.PersonName))
            //    throw new ArgumentException("person name is null");

            //==== instead of validate each prop we can use ValidationContext and
            // validate all props like this =>

            ValidationHelper.ModelValidation(Person);

            Person personConvert =  Person.ToPerson();

            personConvert.PersonID =  Guid.NewGuid();

            _person.Add(personConvert);

            return Convert(personConvert);
        }

        public List<PersonResponse> GetPersonList()
        {
            
            return _person.Select(p=> p.ToPersonResponse()).ToList();

        }

        public PersonResponse? GetPersonById(Guid? Id)
        {
            if(Id == null) 
                return null;
            Person? person = _person.FirstOrDefault(p => p.PersonID == Id);
            if(person == null)
                return null;
            return person.ToPersonResponse();
        }
    }
}
