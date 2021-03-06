﻿using DapperSample.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ObjectDumper;
using System.Configuration;

namespace DapperSample.Models.Repository 
{
   public class ProductRepository
   {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            using (var sqlConnection = new SqlConnection(ConnectionString)) 
            {
                var result = sqlConnection.Query<Product>("Select * from Products");
        
                foreach (Product product in result) 
                    products.Add(product);
            }

            return products;
        }

        public List<Product> GetProductBySupplier(int supplierId) 
        {

            var query = @" Select * from Products
                           join Suppliers on Products.SupplierId = Supplier.Id
                           where SupplierId = @SupplierId; ";

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var products = sqlConnection.Query<Product>(query, new { SupplierId = supplierId });

                return products.ToList();
            }
        }

        public Product GetProductById(int productId) 
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                return sqlConnection.Query<Product>("Select * from Products where Id = @Id", new { Id = productId }).SingleOrDefault();
            }

        }
        public void Delete(int Id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                
                sqlConnection.Execute("DELETE FROM Products WHERE ProductId = " + Id + "");
            }
        }

    }
}
