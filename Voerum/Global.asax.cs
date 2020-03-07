using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Voerum.Models;

namespace Voerum
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            setIngredients();
        }

        private void setIngredients()
        {
            IngredientList ingredientList = new IngredientList();
            ApplicationDbContext _context = new ApplicationDbContext();
            Ingredients ingr = new Ingredients();


            if (!_context.Ingredients.Any())
            {
                foreach (var l in ingredientList.getIngredients())
                {
                    ingr.Name = l;
                    _context.Ingredients.Add(ingr);
                    _context.SaveChanges();
                }
            }
        }
    }
}