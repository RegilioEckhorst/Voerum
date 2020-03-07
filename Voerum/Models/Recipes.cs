using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc.Routing.Constraints;

namespace Voerum.Models
{
    public class Recipes
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength:255)]
        [Symbols]
        [Required(ErrorMessage = "Geef je recept een naam")]
        
        public String Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsPublic { get; set; } = false;

        public string UserId { get; set; } = "";

        [StringLength(maximumLength:1020)]
        [Display(Name = "Beschrijving ")]
        public string Beschrijving { get; set; }
    }
}