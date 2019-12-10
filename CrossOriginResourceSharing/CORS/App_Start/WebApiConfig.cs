using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using CORS.Filters;

namespace CORS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // spesifik domainlere izin vermek icin origins=> https://localhost:44319/api/products, https://localhost:44219/api/products
            // Attribute [EnableCors("*","*","*")]
            EnableCorsAttribute cors = new EnableCorsAttribute("*","*","*");
            config.EnableCors(cors);

            //Diğer Yol
            config.Formatters.Remove(config.Formatters.JsonFormatter);
            config.Formatters.Add(new JsonFormatter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
