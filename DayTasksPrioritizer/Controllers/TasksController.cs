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

        //[HttpPost]
        public ActionResult Prioritize(List<string> tasks)
        {
            var tasksModel = new TasksModel();
            tasksModel.TasksList = new List<TaskModel>();

            foreach (var task in tasks)
            {
                if (task != "")
                {
                    tasksModel.TasksList.Add(new TaskModel()
                    {
                        Name = task,
                        Priority = 0
                    });
                }
            }
            return Json(View(tasksModel));
           // return View("Prioritize", tasksModel);
        }

        //public ActionResult Prioritize(TasksModel tasks)
        //{
        //    return View(tasks);
        //}
	}
}