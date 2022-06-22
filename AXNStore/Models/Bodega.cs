using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXNStore.Models
{
    public class Bodega
    {
        [Required]
        public string nombreBodega { get; set; }
    }
}