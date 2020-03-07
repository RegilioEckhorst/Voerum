using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Voerum.Models
{
    public class Ingredients
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength:255)]

        public string Name { get; set; }
    }
}