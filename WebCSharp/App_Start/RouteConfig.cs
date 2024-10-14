using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebCSharp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "Contact",
              url: "lien-he",
              defaults: new { controller = "Contact", action = "Index", link = UrlParameter.Optional },
              namespaces: new[] { "WebCSharp.Controllers" }
        );
            routes.MapRoute(
             name: "Topic",
             url: "tin-tuc",
             defaults: new { controller = "Topic", action = "Index", link = UrlParameter.Optional },
             namespaces: new[] { "WebCSharp.Controllers" }
       );

            routes.MapRoute(
            name: "Category",
            url: "danh-muc/{slug}-{id}",
            defaults: new { controller = "Products", action = "ProductCategory", id = UrlParameter.Optional },
            namespaces: new[] { "WebCSharp.Controllers" }
        );
            routes.MapRoute(
           name: "Brand",
           url: "thuong-hieu/{slug}-{id}",
           defaults: new { controller = "Products", action = "ProductBrand", id = UrlParameter.Optional },
           namespaces: new[] { "WebCSharp.Controllers" }
       );
            routes.MapRoute(
              name: "ProductDetail",
              url: "chi-tiet/{slug}-p{id}",
              defaults: new { controller = "Products", action = "Detail", slug = UrlParameter.Optional },
              namespaces: new[] { "WebCSharp.Controllers" }
          );
            routes.MapRoute(
               name: "Products",
               url: "san-pham",
               defaults: new { controller = "Products", action = "Index", link = UrlParameter.Optional },
               namespaces: new[] { "WebCSharp.Controllers" }
           );
            routes.MapRoute(
              name: "Brands",
              url: "thuong-hieu",
              defaults: new { controller = "Products", action = "ProductBrand", link = UrlParameter.Optional },
              namespaces: new[] { "WebCSharp.Controllers" }
          );
            routes.MapRoute(
               name: "Categories",
               url: "nganh-hang",
               defaults: new { controller = "Products", action = "ProductCategory", id = UrlParameter.Optional },
               namespaces: new[] { "WebCSharp.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebCSharp.Controllers" }
            );
        }
    }
}
