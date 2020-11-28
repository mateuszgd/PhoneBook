using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhoneBook
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new { controller = "People", action = "Home", department = (string)null }
            );

            routes.MapRoute(null,
                "strona",
                new { controller = "People", action = "Home", department = (string)null }
            );

            routes.MapRoute(null,
                "{department}",
                new { controller = "People", action = "Home" }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
