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
                            Player obj = new Player
                            {
                                Fullname = (string)reader["Fullname"],
                                PlayerId = (int)reader["PlayerId"],
                                Nationality = (string)reader["Nationality"],
                                DOB = reader["DOB"] != DBNull.Value ? (DateTime?)reader["DOB"] : null,
                                ClubId = (int)reader["ClubId"],
                                Number = (byte)reader["Number"],
                                Position = (string)reader["Position"]
                            };
                            list.Add(obj);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
