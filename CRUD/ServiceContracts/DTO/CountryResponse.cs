using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.DTO
{
    public class CountryResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != typeof(CountryResponse))
            {
                return false;
            }
            CountryResponse country_to_compare = (CountryResponse)obj;

            return Id == country_to_compare.Id && Name== country_to_compare.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class CountyExtention
    {
        public static CountryResponse ToCountyResponse (this Country country)
        {
            return new CountryResponse() { Id = country.Id, Name = country.Name, };
        }
    }
}
