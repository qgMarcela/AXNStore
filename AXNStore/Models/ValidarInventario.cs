using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXNStore.Models
{
    public class ValidarInventario
    {
        [Required]
        public List<Item> listaProductos { get; set; }


    }

    public class Item
    {
        [Required]
        public int idProducto { get; set; }

        [Required]
        public int cantidadProducto { get; set; }
    }
    
}