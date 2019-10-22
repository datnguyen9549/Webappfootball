using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WebAppFootball.Models
{
    public class CoachRepository:BaseRepository
    {
        //static string connectionString;
        // Dung "constructor static" de khoi tao mot lan mac du tao nhieu doi tuong.
        //static CoachRepository()
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json").Build();
        //    connectionString = configuration.GetConnectionString("football");
        //}
        // default la private
        private static Coach Fetch(IDataReader reader)
        {
            return new Coach
            {
                FullName = (string)reader["Fullname"],
                Id = (int)reader["CoachId"],
                Nationality = (string)reader["Nationality"],
                YearOfBirth = (short)reader["YearOfBirth"]
            };
        }

        static Coach Fetch(IDbCommand command)
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
        
        static List<Coach> FetchAll(IDbCommand command)
        {
            // not good
            using (IDataReader reader = command.ExecuteReader())
            {
                List<Coach> list = new List<Coach>();
                while (reader.Read())
                {
                    Coach obj = Fetch(reader);
                    list.Add(obj);
                }
                return list;
            }
        }

        public List<Coach> GetCoaches()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetCoaches";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    return FetchAll(command);
                }
            }
        }

        public int AddCoach(Coach obj)
        {
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                using(IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "AddCoach";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter[] parameters =
                    {
                        new Parameter{Name="@Fullname",DbType=DbType.String,Value=obj.FullName},
                        new Parameter{Name="@Yearofbirth",DbType=DbType.Int16,Value=obj.YearOfBirth},
                        new Parameter{Name="@Nationality",DbType=DbType.String,Value=obj.Nationality}
                    };
                    SetParameters(command, parameters);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteCoach(int[] a)
        {
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                using(IDbCommand command = connection.CreateCommand())
                {
                    
                    command.CommandText = "Detele";
                    command.CommandType = CommandType.StoredProcedure;
                    IDbDataParameter parameter = command.CreateParameter();
                    // delete voi mot connection string ma nhieu argument
                    parameter.ParameterName = "@id";
                    parameter.DbType = DbType.Int32;
                    command.Parameters.Add(parameter);
                    // delete voi nhiue connection string
                    //Parameter parameter = new Parameter { Name = "@id", DbType = DbType.Int32, Value = id };
                    //SetParameter(command, parameter);
                    connection.Open();
                    int ret = 0;
                    foreach (var id in a)
                    {
                        parameter.Value = id;
                        ret += command.ExecuteNonQuery();
                    }
                    return ret;
                }
            }
        }
        public int DeleteCoaches(int[] a)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {

                    command.CommandText = "DeleteCoaches";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter parameter = new Parameter { Name = "@p", DbType = DbType.String, Value = string.Join(",",a) };
                    SetParameter(command, parameter);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public Coach GetCoachById(int id)
        {
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                using(IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetCoachById";
                    command.CommandType = CommandType.StoredProcedure;
                    SetParameter(command, new Parameter { Name = "@id", Value = id, DbType = DbType.Int32 });
                    connection.Open();
                    return Fetch(command);
                }
            }
        }

        public int EditCoach(Coach obj)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "EditCoach";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter[] parameters =
                    {
                        new Parameter{Name="@id",DbType=DbType.Int32,Value=obj.Id},
                        new Parameter{Name="@Fullname",DbType=DbType.String,Value=obj.FullName},
                        new Parameter{Name="@Yearofbirth",DbType=DbType.Int16,Value=obj.YearOfBirth},
                        new Parameter{Name="@Nationality",DbType=DbType.String,Value=obj.Nationality}
                    };
                    SetParameters(command, parameters);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public List<Coach> Search(string q)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SeachCoach";
                    command.CommandType = CommandType.StoredProcedure;
                    SetParameter(command, new Parameter { Name = "@q", Value = $"%{q}%", DbType = DbType.String });
                    connection.Open();
                    return FetchAll(command);
                    //using (IDataReader reader = command.ExecuteReader())
                    //{
                    //    List<Coach> list = new List<Coach>();
                    //    while (reader.Read())
                    //    {
                    //        list.Add(Fetch(reader));
                    //    }
                    //    return list;
                    //}
                }
            }
        }
    }
}
