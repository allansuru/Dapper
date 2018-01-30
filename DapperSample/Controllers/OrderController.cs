using DapperSample.Models;
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
    [RoutePrefix("Order")]
    public class OrderController : ApiController
    {
        private OrderRepository Repository { get; set; } = new OrderRepository();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok<List<Order>>(this.Repository.GetOrders());
        }
    }
}