using DapperSample.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace DapperSample.Models.Repository 
{
    public class SupplierRepository
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> supplier = new List<Supplier>();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var result = sqlConnection.Query<Supplier>("SELECT * FROM Suppliers");

                foreach (Supplier sup  in result)
                    supplier.Add(sup);
            }

            return supplier;
        }
        public void Save(Supplier model) 
        {
            using (var sqlConnection = new SqlConnection(ConnectionString)) 
            {
                sqlConnection.Execute("INSERT INTO SUPPLIERS(CompanyName,ContactName, City, Country) VALUES (@CompanyName, @ContactName, @City, @Country)", model);
            }
        }

        public List<Supplier> SelectIn(Supplier model)
        {
            List<Supplier> supplier = new List<Supplier>();

            int[] separaIds = model.ids;

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var result = sqlConnection.Query<Supplier>("SELECT * FROM Suppliers");

                if(separaIds.Length == 1)
                {
                    result = sqlConnection.Query<Supplier>("SELECT * FROM Suppliers WHERE SupplierID IN (" + separaIds[0] + ")");
                }
                else if (separaIds.Length == 2)
                {
                    result  = sqlConnection.Query<Supplier>("SELECT * FROM Suppliers WHERE SupplierID IN (" + separaIds[0] + ", " + separaIds[1]  + ")");
                }
                else if(separaIds.Length == 3)
                {
                    result = sqlConnection.Query<Supplier>("SELECT * FROM Suppliers WHERE SupplierID IN (" + separaIds[0] + ", " + separaIds[1] + ", " + separaIds[2] + ")");
                }
                else if (separaIds.Length == 4)
                {
                    result = sqlConnection.Query<Supplier>("SELECT * FROM Suppliers WHERE SupplierID IN (" + separaIds[0] + ", " + separaIds[1] + ", " + separaIds[2] + ", "+ separaIds[3] +") ");
                }

                foreach (Supplier sup in result)
                    supplier.Add(sup);
            }

            return supplier;
        }

        public void Update(Supplier model) 
        {
            using (var sqlConnection = new SqlConnection(ConnectionString)) 
            {
                sqlConnection.Execute(@"UPDATE SUPPLIERS
                                        SET CompanyName = @CompanyName, 
                                            ContactName = @ContactName,
                                            City = @City,
                                            Country = @Country
                                        WHERE ID = @Id", model);
            }
        }

        public void Delete(Supplier model) 
        {
            using (var sqlConnection = new SqlConnection(ConnectionString)) 
            {
                sqlConnection.Execute("DELETE FROM SUPPLIERS WHERE ID = @Id", model);
            }
        }

    }
}