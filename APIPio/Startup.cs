using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin.Security;
using Owin;
using System.Configuration;
using System.Web.Http.Cors;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(APIPio.Startup))]

namespace APIPio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}
