using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DapperSample.Models.Repository
{
    public class OrderRepository
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();

        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var result = sqlConnection.Query<Order>("Select * from Orders");

                foreach (Order order in result)
                    orders.Add(order);
            }

            return orders;
        }
    }
}