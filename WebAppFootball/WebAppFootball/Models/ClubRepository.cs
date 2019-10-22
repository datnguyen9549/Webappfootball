using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFootball.Models
{
    public class ClubRepository:BaseRepository
    {
        public int Edit(Club obj)
        {
            Parameter[] parameters = {
                new Parameter { Name = "@Id", Value = obj.Id, DbType = DbType.Int32 },
                new Parameter { Name = "@Name", Value = obj.Name, DbType = DbType.String },
                new Parameter { Name = "@ShortName", Value = obj.ShortName, DbType = DbType.String },
                new Parameter { Name = "@StadiumId", Value = obj.StadiumId, DbType = DbType.Int32 },
                new Parameter { Name = "@CoachId", Value = obj.CoachId, DbType = DbType.Int32 },
                new Parameter { Name = "@LogoUrl", Value = obj.LogoUrl, DbType = DbType.String },
            };
            return Save("EditClub", parameters);
        }

        public Club GetClubById(int id)
        {
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                using(IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetClubById";
                    command.CommandType = CommandType.StoredProcedure;
                    SetParameter(command, new Parameter { Name = "@Id", Value = id, DbType = DbType.Int32 });
                    connection.Open();
                    using(IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Club obj = new Club
                            {
                                CoachId = (int)reader["CoachId"],
                                Id = (int)reader["ClubId"],
                                LogoUrl = reader["LogoUrl"] != DBNull.Value ? (string)reader["LogoUrl"] : null,
                                Name = (string)reader["ClubName"],
                                ShortName = (string)reader["ShortName"],
                                StadiumId = (int)reader["StadiumId"],
                            };
                            return obj;
                        }
                        return null;
                    }
                }
            }
        }
        public int Add(Club obj)
        {
            Parameter[] parameters = {
                new Parameter { Name = "@Name", Value = obj.Name, DbType = DbType.String },
                new Parameter { Name = "@ShortName", Value = obj.ShortName, DbType = DbType.String },
                new Parameter { Name = "@StadiumId", Value = obj.StadiumId, DbType = DbType.Int32 },
                new Parameter { Name = "@CoachId", Value = obj.CoachId, DbType = DbType.Int32 },
                new Parameter { Name = "@LogoUrl", Value = obj.LogoUrl, DbType = DbType.String },
            };
            return Save("AddClub", parameters);
        }
        public List<Club> GetClubs()
        {
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                using(IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetClubs";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using(IDataReader reader = command.ExecuteReader())
                    {
                        List<Club> clubs = new List<Club>();
                        while (reader.Read())
                        {
                            Club obj = new Club
                            {
                                CoachId = (int)reader["CoachId"],
                                Id = (int)reader["ClubId"],
                                LogoUrl = reader["LogoUrl"] != DBNull.Value? (string)reader["LogoUrl"]:null,
                                Name = (string)reader["ClubName"],
                                ShortName = (string)reader["ShortName"],
                                StadiumId = (int)reader["StadiumId"],
                                FullName = (string)reader["FullName"],
                                StadiumName = (string)reader["StadiumName"]
                            };
                            clubs.Add(obj);
                        }
                        return clubs;
                    }
                }
            }
        }
    }
}
