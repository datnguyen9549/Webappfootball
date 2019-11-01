using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebAppFootball.Models
{
    public class PositionRepository:BaseRepository
    {
        public List<Position> GetPosition()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Getpositions";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        List<Position> list = new List<Position>();
                        while (reader.Read())
                        {
                            list.Add(new Position
                            {
                                Id = (string)reader["PositionId"],
                                Name = (string)reader["PositionName"]
                            });
                        }
                        return list;
                    }
                }
            }
        }
    }
}
