using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Voerum.Models;
using Voerum.ViewModel;

namespace Voerum.Controllers
{
    [Authorize]
    public class EnvironmentController : Controller
    {
        private ApplicationDbContext _context;
        private string userId;

        public EnvironmentController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET: Environment
        public ActionResult Index()
        {
            userId = User.Identity.GetUserId();

            var newViewModel = new NewViewModel
            {
                Recipes = _context.Recipes
                                .Where(b => b.UserId == userId)
                                .ToList(),
                
            };
            return View(newViewModel);
        }

        [HttpPost]
        public ActionResult CreateRecipe(NewViewModel newViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewViewModel
                {
                    Ingredients = _context.Ingredients.ToList()

                };
                return View("Save", viewModel);
            }

            var recipe = new Recipes();
            recipe.UserId = User.Identity.GetUserId();

            if (newViewModel != null)
            {
                recipe.Name = newViewModel.Recipes[0].Name;
                recipe.IsPublic = newViewModel.Recipes[0].IsPublic;
                recipe.Beschrijving = newViewModel.Recipes[0].Beschrijving;

                _context.Recipes.Add(recipe);
                int id = recipe.Id;
                _context.SaveChanges();
                id = recipe.Id;

                var hasIngredients = new HasIngredients();

                foreach (var ingredients in newViewModel.Ingredients)
                {
                    if (ingredients.Name != null)
                    {
                        //Get id from db based on the name
                        var blog = _context.Ingredients
                            .Where(b => b.Name == ingredients.Name)
                            .FirstOrDefault();

                        //Set id in db as foreign keys
                        hasIngredients.RecipesId = recipe.Id;
                        hasIngredients.ingredientsId = blog.Id;

                        _context.HasIngredients.Add(hasIngredients);
                        _context.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult NewRecipe()
        {
            var ingredienten = _context.Ingredients.ToList();

            var viewModel = new NewViewModel
            {
                Ingredients = ingredienten
            };
            return View("Save", viewModel);
        }

        public ActionResult ViewRecipe(int id)
        {
            var recept = _context.Recipes.SingleOrDefault(c => c.Id == id);
            List<Recipes> rc = new List<Recipes>();
            rc.Add(recept);
            int rID = rc[0].Id;

            var newViewModel = new NewViewModel
            {
                Recipes = rc,
                Ingredients = (from d in _context.Ingredients
                        join f in _context.HasIngredients
                            on d.Id equals f.ingredientsId
                               where f.Recipes.Id.Equals(rID)
                               select d).ToList()
            };
            return View(newViewModel);
        }

       
        public ActionResult Delete(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(c => c.Id == id);

            _context.Recipes.Attach(recipe);
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
            return RedirectToAction("Index", "Environment");
        }

        public ActionResult PublicRecipes()
        {
            String uid = User.Identity.GetUserId();
            NewViewModel newViewModel = new NewViewModel()
            {
                Recipes = _context.Recipes
                    .Where(b => b.UserId != uid)
                    .Where(c=> c.IsPublic)
                    .ToList()
            };
            return View(newViewModel);
        }
    }
}