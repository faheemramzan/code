using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Assignment.Models;
using Assignment.Services.Interfaces;
using Assignment.Services.Mocks;
using Assignment.Services;

namespace Assignment.Controllers
{
    public class PersonsController : ApiController
    {

        //private IPersonService _personService = new Persons();
        private IPersonService _personService = new PersonsMock();

        public IEnumerable<Person> Get()
        {
            return _personService.Get();
        }

        public Person Add(Person person)
        {
            return _personService.Add(person);
        }
    }
}
