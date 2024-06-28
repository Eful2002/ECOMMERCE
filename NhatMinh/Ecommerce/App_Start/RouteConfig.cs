using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ecommerce
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Route for Admin area
            routes.MapRoute(
                name: "Admin",
                url: "Admin",
                defaults: new { area = "Admin", controller = "DangNhap", action = "DangNhap" },
                namespaces: new[] { "Ecommerce.Areas.Admin.Controllers" }
            ).DataTokens.Add("area", "Admin");

            // Default route for Customers area
            routes.MapRoute(
                name: "Customers",
                url: "{controller}/{action}/{id}",
                defaults: new { area = "Customers", controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Ecommerce.Areas.Customers.Controllers" }
            ).DataTokens.Add("area", "Customers");
        }
    }
}
