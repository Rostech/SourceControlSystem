﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SourceControlSystem.Api.Startup))]

namespace SourceControlSystem.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // 3.15
            // 2.26.54 za da moje da se injektira v servicite
            // perfektnata situaciq e na vseki edin request da imame po 1 db context.
            // Of model da napravim originalen database model 2.58
            // Test branch
        }
    }
}
