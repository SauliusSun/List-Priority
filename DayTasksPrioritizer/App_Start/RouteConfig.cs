using System.Web.Mvc;
using System.Web.Routing;

namespace DayTasksPrioritizer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Tasks", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
