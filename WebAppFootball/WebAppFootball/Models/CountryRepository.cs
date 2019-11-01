using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFootball.Models
{
    public class CountryRepository: BaseRepository
    {
        public List<Country> GetCountries()
        {
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                using(IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetCountries";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using(IDataReader reader = command.ExecuteReader())
                    {
                        List<Country> list = new List<Country>();
                        while (reader.Read())
                        {
                            list.Add(new Country
                            {
                                Id = (string)reader["CountryId"],
                                Name = (string)reader["CountryName"]
                            });
                        }
                        return list;
                    }
                }
            }
        }
    }
}
