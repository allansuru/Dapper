using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DapperSample.Models.Repository
{
    public class FavoritesRepository
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ToString();

        public List<Favorites> GetFavorites()
        {
            List<Favorites> favorites = new List<Favorites>();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var result = sqlConnection.Query<Favorites>("Select * from Favorites");

                foreach (Favorites favorite in result)
                    favorites.Add(favorite);
            }

            return favorites;
        }

        public void Save(Favorites model)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                if (model.IdFavorites == 0)
                    sqlConnection.Execute("INSERT INTO Favorites(ID_User, ID_Component, CreateFavorite, EhFavorito) VALUES (@ID_User, @ID_Component, @CreateFavorite, @EhFavorito)", model);
                else
                    sqlConnection.Execute(@"UPDATE Favorites SET EhFavorito = @EhFavorito WHERE IDFavorites = @IDFavorites", model);
            }
        }
    }
}