using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFootball.Models
{
    public class PlayerRepository: BaseRepository
    {
        static List<Player> Fetchall(IDbCommand command)
        {
            
            using (IDataReader reader = command.ExecuteReader())
            {
                List<Player> list = new List<Player>();
                while (reader.Read())
                {

                    list.Add(Fetch(reader));
                }
                return list;
            }
        }
        public int Delete(int id)
        {
            return Save("DeletePlayer", new Parameter { Name = "@id", Value = id, DbType = DbType.Int32 });
        }
        public int Edit(Player obj)
        {
            Parameter[] parameter =
            {
                new Parameter{Name = "@PlayerId",Value=obj.PlayerId,DbType=DbType.Int32},
                new Parameter{Name = "@FullName",Value=obj.Fullname,DbType=DbType.String},
                new Parameter{Name = "@ClubId",Value=obj.ClubId,DbType=DbType.Int32},
                new Parameter{Name = "@PositionId",Value=obj.PositionId,DbType=DbType.String},
                new Parameter{Name = "@Number",Value=obj.Number,DbType=DbType.Byte},
                new Parameter{Name = "@Nationality",Value=obj.Nationality,DbType=DbType.String},
                new Parameter{Name = "@DOB",Value=obj.DOB,DbType=DbType.Date},
            };
            return Save("EditPlayer", parameter);
        }
        public Player GetPlayerById(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetPlayerById";
                    command.CommandType = CommandType.StoredProcedure;

                    SetParameter(command, new Parameter { Name = "@Id", Value = id, DbType = DbType.Int32 });
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Fetch2(reader);
                        }
                        return null;
                    }
                }
            }
        }
        static Player Fetch2(IDataReader reader)
        {
            return new Player
            {
                Fullname = (string)reader["Fullname"],
                PlayerId = (int)reader["PlayerId"],
                Nationality = (string)reader["Nationality"],
                ClubId = (int)reader["ClubId"],
                Number = (byte)reader["Number"],
                PositionId = (string)reader["PositionId"],
                DOB = reader["DOB"] != DBNull.Value ? (DateTime?)reader["DOB"] : null,
            };
        }
        public int Add(Player obj)
        {
            Parameter[] parameter =
            {
                new Parameter{Name = "@FullName",Value=obj.Fullname,DbType=DbType.String},
                new Parameter{Name = "@ClubId",Value=obj.ClubId,DbType=DbType.Int32},
                new Parameter{Name = "@PositionId",Value=obj.PositionId,DbType=DbType.String},
                new Parameter{Name = "@Number",Value=obj.Number,DbType=DbType.Byte},
                new Parameter{Name = "@Nationality",Value=obj.Nationality,DbType=DbType.String},
                new Parameter{Name = "@DOB",Value=obj.DOB,DbType=DbType.Date},
            };
            return Save("AddPlayer", parameter);
        }
        static Player Fetch(IDataReader reader)
        {
            return new Player
            {
                Fullname = (string)reader["Fullname"],
                PlayerId = (int)reader["PlayerId"],
                Nationality = (string)reader["Nationality"],
                CountryName = (string)reader["CountryName"],
                DOB = reader["DOB"] != DBNull.Value ? (DateTime?)reader["DOB"] : null,
                ClubId = (int)reader["ClubId"],
                ClubName = (string)reader["ClubName"],
                Number = (byte)reader["Number"],
                PositionId = (string)reader["PositionId"],
                PositionName = (string)reader["PositionName"]
            };
        }
        public List<Player> GetPlayers()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetPlayers";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        List<Player> list = new List<Player>();
                        while (reader.Read())
                        {
                            
                            list.Add(Fetch(reader));
                        }
                        return list;
                    }
                }
            }
        }

        public List<Player> GetPlayers(int index, int size, out int page)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetPlayers";
                    Parameter[] parameters =
                    {
                        new Parameter{Name="@start", Value = (index - 1) * size + 1, DbType=DbType.Int32},
                        new Parameter{Name="@end", Value= index * size, DbType=DbType.Int32},
                        new Parameter{Name="@ret",Direction=ParameterDirection.ReturnValue,DbType=DbType.Int32}
                    };
                    SetParameters(command, parameters);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    //List<Player> list = new List<Player>();
                    //using (IDataReader reader = command.ExecuteReader())
                    //{
                    //    while (reader.Read())
                    //    {

                    //        list.Add(Fetch(reader));
                    //    }
                    //}
                    List<Player> list = Fetchall(command);
                    IDataParameter parameter = (IDataParameter)command.Parameters["@ret"];
                    int total = (int)parameter.Value;
                    page = ((total - 1) / size) + 1;
                    return list;
                }
            }
        }

        public List<Player> SearchPlayers(string q, int index, int size, out int page)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SearchPlayers";
                    Parameter[] parameters =
                    {
                        new Parameter{Name="@q", Value = q, DbType = DbType.String},
                        new Parameter{Name="@start", Value = (index - 1) * size + 1, DbType=DbType.Int32},
                        new Parameter{Name="@end", Value= index * size, DbType=DbType.Int32},
                        new Parameter{Name="@ret",Direction=ParameterDirection.ReturnValue,DbType=DbType.Int32}
                    };
                    SetParameters(command, parameters);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    //List<Player> list = new List<Player>();
                    //using (IDataReader reader = command.ExecuteReader())
                    //{
                    //    while (reader.Read())
                    //    {

                    //        list.Add(Fetch(reader));
                    //    }
                    //}
                    List<Player> list = Fetchall(command);
                    IDataParameter parameter = (IDataParameter)command.Parameters["@ret"];
                    int total = (int)parameter.Value;
                    page = ((total - 1) / size) + 1;
                    return list;
                }
            }
        }
    }
}
