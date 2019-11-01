using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WebAppFootball.Models
{
    //dung abstract de class con ke thua va co the overried
    public abstract class BaseRepository
    {
        // Dung static de user ko the tao moi mot object connectionString
        // Dung protected de user ko the thay doi object connectionString
        protected static string connectionString;
        static BaseRepository()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            connectionString = configuration.GetConnectionString("football");
        }
        protected static void SetParameter(IDbCommand command, Parameter parameter)
        {
            IDbDataParameter dbDataParameter = command.CreateParameter();
            dbDataParameter.Value = parameter.Value;
            dbDataParameter.ParameterName = parameter.Name;
            dbDataParameter.DbType = parameter.DbType;
            if (Enum.IsDefined(typeof(ParameterDirection), parameter.Direction))
            {
                dbDataParameter.Direction = parameter.Direction;
            }
            command.Parameters.Add(dbDataParameter);
        }

        protected static void SetParameters(IDbCommand command, Parameter[] parameters)
        {
            foreach (var parameter in parameters)
            {
                SetParameter(command, parameter);
            }
        }
        protected int Save(string sql, Parameter[] parameters)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    command.CommandType = CommandType.StoredProcedure;
                    SetParameters(command, parameters);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
        protected int Save(string sql, Parameter parameters)
        {
            return Save(sql, new Parameter[] { parameters });
        }
    }
}
