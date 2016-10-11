using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment.Models;
using Assignment.Services.Interfaces;
using Assignment.Services.Mocks;
using Assignment.Services;

namespace Assignment.Controllers
{
    public class CompaniesController : ApiController
    {

        private ICompanyService _companyService = new CompaniesMock();
        //private ICompanyService _companyService = new Companies();

        public IEnumerable<Company> Get()
        {
            return _companyService.Get();
        }

        public Company Add(Company company)
        {
            return _companyService.Add(company);           
        }
    }
}