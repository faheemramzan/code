using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment.Services.Interfaces;
using Assignment.Models;

namespace Assignment.Services.Mocks
{
    public class PersonsMock: IPersonService
    {
        private Person[] _persons =
            new[]
            {
                new Person() { Key=1, Name="Faheem", CompanyKey=1 },
                new Person() { Key=2, Name="Anna", CompanyKey=2 },
                new Person() { Key=3, Name="Davíd" }
            };

        public Person[] Get()
        {
            return _persons;
        }
        
        public Person Add(Person person)
        {
            _persons = _persons.Concat(new[] { person }).ToArray();
            return person;
        }
    }
}