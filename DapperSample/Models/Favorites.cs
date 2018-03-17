using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperSample.Models.Repository
{
    public class Favorites
    {
        public int IdFavorites { get; set; }
        public int Id_User { get; set; }
        public int Id_Component { get; set; }
        public DateTime CreateFavorite { get; set; }
        public bool EhFavorito { get; set; }
    }
}