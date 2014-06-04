using System.Web.Mvc;
using System.Web.Routing;

namespace DayTasksPrioritizer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // remove all view engines registered in application
            ViewEngines.Engines.Clear();
            
            // add Razor view engine
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
