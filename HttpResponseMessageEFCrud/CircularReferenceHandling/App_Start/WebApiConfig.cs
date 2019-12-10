using System.Web.Http;

namespace CircularReferenceHandling
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Hoştur ama benana her seferinde sorgu atıyor her seferinde sorgu atıyor bu nasıl tembellik. DTO

            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
            //    Newtonsoft.Json.ReferenceLoopHandling.Ignore;


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }
}