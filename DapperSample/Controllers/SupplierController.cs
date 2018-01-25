using DapperSample.Model;
using DapperSample.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DapperSample.Controllers
{
    [EnableCors(origins: "http://localhost:55150", headers: "*", methods: "*")]
    [RoutePrefix("Supplier")]
    public class SupplierController : ApiController
    {
        private SupplierRepository Repository { get; set; } = new SupplierRepository();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok<List<Supplier>>(this.Repository.GetSuppliers());
        }



        [HttpPost]
        public IHttpActionResult GetIn(Supplier model)
        {
           
            return Ok<List<Supplier>>(this.Repository.SelectIn(model));
        }

     /*   [HttpPost]
        public IHttpActionResult Post(Supplier model) 
        {
            this.Repository.Save(model);
            return Ok();
        } */

        [HttpPut]
        public IHttpActionResult Put(Supplier model) 
        {
            this.Repository.Update(model);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(Supplier model) 
        {
            this.Repository.Delete(model);
            return Ok();
        }
    }
}
