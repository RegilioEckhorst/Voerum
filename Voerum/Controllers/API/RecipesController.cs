using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Voerum.Models;

namespace Voerum.Controllers.API
{
    public class RecipesController : ApiController
    {
        private ApplicationDbContext _context;
        public RecipesController()
        {
            _context = new ApplicationDbContext();
        }

        //Get/API/Recipes
        public IEnumerable<Recipes> GetRecipes()
        {
            return _context.Recipes.ToList();
        }

        //Get/API/recipes/1
        public Recipes GetRecipe(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(c => c.Id == id);
            if (recipe == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return recipe;

        }

        //Post/API/Recipes
        [HttpPost]
        public Recipes CreateRecipe(Recipes recipe)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return recipe;
        }

        [HttpPut]
        public void UpdateRecipe(int id, Recipes recipes)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var recipeInDb = _context.Recipes.SingleOrDefault(c => c.Id == id);

            if (recipeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            recipeInDb.Name = recipes.Name;
            recipeInDb.Beschrijving = recipes.Beschrijving;
            recipeInDb.CreatedAt = recipes.CreatedAt;

            _context.SaveChanges();
        }

        //DELETE /API/Recipes/1
        [HttpDelete]
        public void DeleteRecipes(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var recipeInDb = _context.Recipes.SingleOrDefault(c => c.Id == id);

            if (recipeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Recipes.Remove(recipeInDb);
            _context.SaveChanges();
        }
    }
}
