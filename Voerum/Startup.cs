using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Voerum.Models;

[assembly: OwinStartupAttribute(typeof(Voerum.Startup))]
namespace Voerum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }


    }
}