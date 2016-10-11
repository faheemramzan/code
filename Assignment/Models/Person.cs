using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Person
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public int? CompanyKey { get; set; }
    }
}