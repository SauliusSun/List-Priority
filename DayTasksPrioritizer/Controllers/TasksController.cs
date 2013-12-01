using System.Collections.Generic;
using System.Web.Mvc;
using DayTasksPrioritizer.Models;

namespace DayTasksPrioritizer.Controllers
{
    public class TasksController : Controller
    {
        public ActionResult Index()
        {
            var tasksModel = new List<TaskModel>();

            tasksModel.Add(new TaskModel()
            {
                Name = "Dienos užduotis 1",
                Priority = 0
            });

            tasksModel.Add(new TaskModel()
            {
                Name = "Dienos užduotis 2",
                Priority = 0
            });


            tasksModel.Add(new TaskModel()
            {
                Name = "Dienos užduotis 3",
                Priority = 0
            });



            return View(tasksModel);
        }
	}
}