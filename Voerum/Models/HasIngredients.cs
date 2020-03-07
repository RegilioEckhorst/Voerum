using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Voerum.Models
{
    public class HasIngredients
    {
        [Key]
        public int Id { get; set; }

        public Recipes Recipes { get; set; }
        public int RecipesId { get; set; }

        public Ingredients Ingredients {get; set; }
        public int ingredientsId { get; set; }
    }
}