using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Voerum.Models;

namespace Voerum.ViewModel
{
    public class NewViewModel
    {
        public List<Recipes> Recipes { get; set; }
        public List<Ingredients> Ingredients { get; set; }
    }
}