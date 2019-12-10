using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using MediaTypeFormatter.MediaFormatters;
using Newtonsoft.Json.Serialization;

namespace MediaTypeFormatter
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // raw güzelleştirici
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            // camelCase Property
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Csv desteği
            config.Formatters.Add(new ProductCsvFormatter(new QueryStringMapping("format","csv","text/csv")));

            // Disabled Xml
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            //Disabled Json
            //config.Formatters.Remove(config.Formatters.JsonFormatter);

            // Browser Json return
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

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
