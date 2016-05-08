using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace KeesingTechnologies.Assignment.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "v1/{controller}/{Action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // always return json
            var json = config.Formatters.JsonFormatter;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
