using DapperSample.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DapperSample.Controllers
{
    [EnableCors(origins: "http://localhost:55150", headers: "*", methods: "*")]
    [RoutePrefix("Favorite")]
    public class FavoriteController : ApiController
    {
        private FavoritesRepository Repository { get; set; } = new FavoritesRepository();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok<List<Favorites>>(this.Repository.GetFavorites());
        }

        [HttpPost]
        public IHttpActionResult Save(Favorites model)
        {
            this.Repository.Save(model);
            return Ok();
        }
    }
}