using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment.Services.Interfaces;
using Assignment.Models;
using System.Data.SqlClient;
using System.Data;

namespace Assignment.Services
{
    public class Companies : ICompanyService
    {
        public Company[] Get()
        {
            using (var sqlConnection = Helper.CreateDatabaseConnection())
            {
                sqlConnection.Open();

                using (var sqlCommand = new SqlCommand(@"select [Key], Name from Company", sqlConnection))
                {
                    using (var sqlReader = sqlCommand.ExecuteReader())
                    {
                        return sqlReader.OfType<System.Data.Common.DbDataRecord>()
                                .Select(company => 
                                    new Company()
                                    {
                                        Key = company.GetInt32(0),
                                        Name = company.GetString(1)
                                    }
                                ).ToArray();
                    }                    
                }
            }
        }

        public Company Add(Company company)
        {
            using (var sqlConnection = Helper.CreateDatabaseConnection())
            {
                sqlConnection.Open();

                using (var sqlCommand = new SqlCommand(@"insert into Company (Name) values(@name)
                                                        set @key=SCOPE_IDENTITY()", sqlConnection))
                {

                    sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = company.Name;

                    var key = sqlCommand.Parameters.Add("@key", SqlDbType.Int);
                    key.Direction = ParameterDirection.Output;

                    if (sqlCommand.ExecuteNonQuery() != 1)
                    {
                        throw new ApplicationException(
                            String.Format("Could not add company {0}!", company.Name)
                            );
                    }

                    company.Key = Convert.ToInt32(key.Value);
                    return company;
                }
            }
        }
    }
}