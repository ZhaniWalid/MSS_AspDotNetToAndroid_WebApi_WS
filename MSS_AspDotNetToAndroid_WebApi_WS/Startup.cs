using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(MSS_AspDotNetToAndroid_WebApi_WS.Startup))]

namespace MSS_AspDotNetToAndroid_WebApi_WS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // added by me
            
           /* HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            GlobalConfiguration.Configure(WebApiConfig.Register);*/
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //app.UseWebApi(config);
            
            // fin added by me
        }
    }
}
