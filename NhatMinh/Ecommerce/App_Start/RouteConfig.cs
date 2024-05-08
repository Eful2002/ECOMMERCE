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

            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { Controller = "DangNhap", action = "DangNhap", id = UrlParameter.Optional },
              namespaces: new string[] { "Ecommerce.Areas.Admin.Controllers" }
          ).DataTokens.Add("area", "Admin");
        }
    }
}

