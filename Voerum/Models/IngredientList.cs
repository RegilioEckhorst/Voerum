using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Voerum.Models
{
    public class IngredientList
    {
        public List<String> getIngredients()
        {
            List<String> ingredients = new List<String>();

            ingredients.Add("Pasta");
            ingredients.Add("Friet");
            ingredients.Add("Aardappelen");
            ingredients.Add("Rijst");
            ingredients.Add("Tortilla");
            ingredients.Add("Burrito");
            ingredients.Add("Dorritos");

            ingredients.Add("Pizzasaus");
            ingredients.Add("Ketchup");
            ingredients.Add("Mayonaise");
            ingredients.Add("Knoflooksaus");
            ingredients.Add("Satesaus");

            ingredients.Add("Kip");
            ingredients.Add("Varken");
            ingredients.Add("Gehakt");
            ingredients.Add("Spareribs");
            ingredients.Add("Biefstuk");
            ingredients.Add("Kalkoen");

            ingredients.Add("Uien");
            ingredients.Add("Tomaat");
            ingredients.Add("Knoflook");
            ingredients.Add("Wortel");
            ingredients.Add("Prei");
            ingredients.Add("Ijsbergsla");

            ingredients.Add("Zout");
            ingredients.Add("Peper");
            ingredients.Add("Cayennepeper");
            ingredients.Add("Kerrie");

            ingredients.Add("Olijfolie");
            ingredients.Add("Roomboter");
            ingredients.Add("Slaolie");
            ingredients.Add("Zonnebloemolie");

            return ingredients;
        }
    }
}