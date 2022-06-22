using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXNStore.Models
{
    public class Producto
    {
        [Required]
        public string nombreProducto { get; set; }

    }
}