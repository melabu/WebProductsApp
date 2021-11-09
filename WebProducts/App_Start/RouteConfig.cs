﻿using System.Web.Mvc;
using System.Web.Routing;

namespace WebProducts
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "IndexByCategory",
                url: "{controller}/{action}/{category}",
                defaults: new 
                { 
                    controller = "Product", 
                    action = "Index", 
                    category = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
