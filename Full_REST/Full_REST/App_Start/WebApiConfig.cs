using System.Web.Http;

namespace Full_REST
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "SecondaryRoute",
                routeTemplate: "api/{comtroller}/{author}",
                defaults: new { author = RouteParameter.Optional }
            );
        }
    }
}
