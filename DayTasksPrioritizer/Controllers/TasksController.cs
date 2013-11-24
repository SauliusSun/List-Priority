using System.Web.Mvc;

namespace DayTasksPrioritizer.Controllers
{
    public class TasksController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}