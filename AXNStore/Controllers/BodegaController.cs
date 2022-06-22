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
    public class BodegaController : ApiController
    {
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        /// <summary>
        /// Este metodo
        /// </summary>
        /// <param name="bodega"></param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody] Bodega bodega)
        {
            String respuesta = "";

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (DataBodega.RegistrarBodega(bodega))
            {
                respuesta = "Bodega almacenada";
            }
            else
            {
                respuesta = "La bodega no se pudo almacenar";
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