using CSharpFunctionalExtensions;
using PetFamily.Domain.Volunteer;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Shared
{
    //пока для простоты просто структура с полями. 
    //стоит заводить сущностями в БД, может отдельной - адресный классификатор, чтобы можно было фильтровать по стране/области/городу
    //ну или это все такие ValueObject
    public class Address 
    {
        public string Building { get; }
        public string Street { get; }
        public string City { get; }
        public string State { get;}
        public string Country { get; }
        public string IndexCode { get; }

        private Address(string street, string city, string state, string country,string building, string indexCode)
        {
            Building = building;
            Street = street;
            City = city;
            State = state;
            Country = country;
            IndexCode = indexCode;
        }

        public static Address NewAddress(string street, string city, string state, string country, string building, string indexCode) 
            => new(street, city,state, country, building, indexCode);
        public static string AddressByString(Address address)
        {
            return $"{address.IndexCode}, {address.Country.ToUpperInvariant()}, {address.State}, {address.City}, {address.Street}, {address.Building}";
        }
    }
}
