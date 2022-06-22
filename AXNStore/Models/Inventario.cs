using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXNStore.Models
{
    public class Inventario
    {
        [Required]
        public int idProducto { get; set; }
        [Required]
        public int idBodega { get; set; }
        [Required]
        public int cantidadInventario { get; set; }

    }
}