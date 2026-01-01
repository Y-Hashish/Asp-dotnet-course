using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts
{
    public interface IPersonService
    {
        PersonResponse AddPerson(PersonAddRequest? Person);
        List<PersonResponse> GetPersonList();
        PersonResponse? GetPersonById(Guid? Id);
        List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString);
    }
}
