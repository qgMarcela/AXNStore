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
    public class InventarioController : ApiController
    {

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] ValidarInventario validar)
        {
            dynamic respuesta = null;

            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }

            respuesta=DataInventario.ValidarInventario(validar);

            if (respuesta == null) { 
                 return BadRequest("No se encontró inventario para el producto indicado");
            }
           
            return Ok(respuesta);

        }

        // PUT api/<controller>/5
        public IHttpActionResult Put([FromBody] Inventario inventario)
        {
            String respuesta = "";

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (DataInventario.EntradasInventario(inventario))
            {
                respuesta = "Entrada de inventario almacenada";
            }
            else
            {
                respuesta = "La entrada de inventario no se pudo almacenar";
            }

            return Ok(respuesta);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}