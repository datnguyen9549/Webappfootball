using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFootball.Models
{
    public class MatchRepository: BaseRepository
    {
        static Match Fetch(IDataReader reader)
        {
            return new Match
            {
                Id = (int)reader["MatchId"],
                AwayClub = (int)reader["AwayClub"],
                AwayClubName = (string)reader["AwayClubName"],
                HomeClub = (int)reader["HomeClub"],
                HomeClubName = (string)reader["HomeClubName"],
                Result = (string)reader["Result"],
                Round = (byte)reader["Round"],
                StadiumId = (int)reader["StadiumId"],
                Status = (byte)reader["Status"],
                AwayLogo = (string)reader["AwayLogo"],
                HomeLogo = (string)reader["HomeLogo"],
                StadiumName = (string)reader["StadiumName"]
            };
        }

        public List<Match> GetMatches()
        {
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                using(IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetMatch";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using(IDataReader reader = command.ExecuteReader())
                    {
                        List<Match> matches = new List<Match>();
                        while (reader.Read())
                        {
                            matches.Add(Fetch(reader));
                        }
                        return matches;
                    }
                }
            }
        }

        public List<Match>[] GetMatches2()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "GetMatch";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        List<Match>[] matches = new List<Match>[38];
                        for (int i = 0; i < matches.Length; i++)
                        {
                            matches[i] = new List<Match>();
                        }
                        while (reader.Read())
                        {
                            Match item = Fetch(reader);
                            matches[item.Round - 1].Add(item);
                        }
                        return matches;
                    }
                }
            }
        }
    }
}
