using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment.Services.Interfaces;
using Assignment.Models;

namespace Assignment.Services.Mocks
{
    public class CompaniesMock: ICompanyService
    {
        private Company[] _companies =
            new[]
            {
                new Company() { Key=1, Name="Värderingsdata AB" },
                new Company() { Key=2, Name="ÅF AB" }
            };

        public Company[] Get()
        {
            return _companies;
        }

        public Company Add(Company company)
        {
            _companies = _companies.Concat(new[] { company }).ToArray();
            return company;
        }
    }
}