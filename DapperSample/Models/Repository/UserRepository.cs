using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DapperSample.Models.Repository
{
    public class UserRepository
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();

        public User Find(string userId)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                return sqlConnection.QueryFirstOrDefault<User>(
                    "SELECT UserID, AccessKey " +
                    "FROM dbo.Users " +
                    "WHERE UserID = @UserID", new { UserID = userId });
            }
        }
    }
}