using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace R5AppDataWebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger(new TraceSource("R5AppDataWebService", SourceLevels.All)));
        }
    }
}
