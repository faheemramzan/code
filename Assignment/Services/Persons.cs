using System;
using System.Linq;
using Assignment.Models;
using System.Data.SqlClient;
using Assignment.Services.Interfaces;
using System.Data;

namespace Assignment.Services
{
    public class Persons : IPersonService
    {
        public Person[] Get()
        {
            using (var sqlConnection = Helper.CreateDatabaseConnection())
            {
                sqlConnection.Open();

                using (var sqlCommand = new SqlCommand(@"select [Key], Name, CompanyKey from Person", sqlConnection))
                {
                    using (var sqlReader = sqlCommand.ExecuteReader())
                    {
                        return sqlReader.OfType<System.Data.Common.DbDataRecord>()
                                .Select(person =>
                                    new Person()
                                    {
                                        Key = person.GetInt32(0),
                                        Name = person.GetString(1),
                                        CompanyKey = person.IsDBNull(2) ? (int?) null : person.GetInt32(2)
                                    }
                                ).ToArray();
                    }
                }
            }
        }

        public Person Add(Person person)
        {
            using (var sqlConnection = Helper.CreateDatabaseConnection())
            {
                sqlConnection.Open();

                using (var sqlCommand = new SqlCommand(@"insert into Person (Name, CompanyKey) values(@name, @companyKey)
                                                        set @key=SCOPE_IDENTITY()", sqlConnection))
                {

                    sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = person.Name;
                    sqlCommand.Parameters.Add("@companyKey", SqlDbType.Int).Value =
                        person.CompanyKey.HasValue ? person.CompanyKey.Value : (object)DBNull.Value;

                    var key = sqlCommand.Parameters.Add("@key", SqlDbType.Int);
                    key.Direction = ParameterDirection.Output;

                    if (sqlCommand.ExecuteNonQuery() != 1)
                    {
                        throw new ApplicationException(
                            String.Format("Could not add person Name: {0}, CompanyKey: {1}!", person.Name, person.CompanyKey)
                            );
                    }

                    person.Key = Convert.ToInt32(key.Value);
                    return person;
                }
            }
        }
    }
}