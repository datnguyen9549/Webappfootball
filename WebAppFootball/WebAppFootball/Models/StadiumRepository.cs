using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFootball.Models
{
    public class StadiumRepository: BaseRepository
    {
        static Stadium Fetch(IDataReader reader)
        {
            Stadium stadium = new Stadium
            {
                Name = (string)reader["StadiumName"],
                Id = (int)reader["StadiumId"],
                City = (string)reader["City"],
                YearOfBeginning = reader["YearOfBeginning"] != DBNull.Value ? (short?)reader["YearOfBeginning"] : null
            };
            return stadium;
        }

        static Stadium Fetch(IDbCommand command)
        {
            using (IDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return Fetch(reader);
                }
                return null;
            }
        }

        public List<Stadium> GetStadium()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using(IDbCommand command= connection.CreateCommand())
                {
                    command.CommandText = "GetStadiums";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using(IDataReader reader = command.ExecuteReader())
                    {
                        List<Stadium> list = new List<Stadium>();
                        while (reader.Read())
                        {
                            //Stadium obj = new Stadium
                            //{
                            //    Id = (int)reader["StadiumId"],
                            //    City = (string)reader["StadiumName"],
                            //    Name = (string)reader["City"],
                            //    YearOfBeginning = reader["YearOfBeginning"] != DBNull.Value ? (short?)reader["YearOfBeginning"] : null
                            //};
                            list.Add(Fetch(reader));
                        }
                        return list;
                    }
                }
            }
        }

        public Stadium GetStadiumbyId(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetStadiumById";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    return Fetch(command);
                }
            }
        }

        public int Add(Stadium obj)
        {
            Parameter[] parameters =
                    {
                        new Parameter{Name="@Name",DbType=DbType.String,Value=obj.Name},
                        new Parameter{Name="@City",DbType=DbType.String,Value=obj.City},
                        new Parameter{Name="@YearOfBeginning",DbType=DbType.Int16,Value=obj.YearOfBeginning}
                    };
            return Save("AddStadium", parameters);
            //using (IDbConnection connection = new SqlConnection(connectionString))
            //{
            //    using (IDbCommand command = connection.CreateCommand())
            //    {
            //        command.CommandText = "AddStadium";
            //        command.CommandType = CommandType.StoredProcedure;
            //        Parameter[] parameters =
            //        {
            //            new Parameter{Name="@Name",DbType=DbType.String,Value=obj.Name},
            //            new Parameter{Name="@City",DbType=DbType.String,Value=obj.City},
            //            new Parameter{Name="@YearOfBeginning",DbType=DbType.Int16,Value=obj.YearOfBeginning}
            //        };
            //        SetParameters(command, parameters);
            //        connection.Open();
            //        return command.ExecuteNonQuery();
            //    }
            //}
        }
        public int delete(int id)
        {
            Parameter parameter = new Parameter { Name = "@Id", DbType = DbType.Int32, Value = id };
            return Save("DeleteStadium", parameter);
        }
    }
}
