using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OdeToFood.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // /trace.axd/1/2/3/4
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                // /greeting/
                url: "{controller}/{action}/{id}",
                // Transform the Id segment of the URL
                // To get the id section from a KEY that show the information inside from the QueryString.
                // url: "{controller}/{action}/{key}", 
                //defaults: new { controller = "Home", action = "Index", key  = UrlParameter.Optional }
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
