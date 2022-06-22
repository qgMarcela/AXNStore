using AXNStore.Data;
using AXNStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AXNStore.Controllers
{
    public class ProductoController : ApiController
    {
         // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Producto producto)
        {
            String respuesta = "";

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (DataProducto.RegistrarProducto(producto))
            {
                respuesta = "Producto almacenado";
            }
            else { 
                respuesta = "El producto no se pudo almacenar"; 
            }

            return Ok(respuesta);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}