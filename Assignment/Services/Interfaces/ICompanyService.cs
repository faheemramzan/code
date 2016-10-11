using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Models;

namespace Assignment.Services.Interfaces
{
    interface ICompanyService
    {
        Company[] Get();
        Company Add(Company company);
    }
}
