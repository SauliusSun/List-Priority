using DayTasksPrioritizer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DayTasksPrioritizer.Controllers
{
    public class TasksController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
           
                //var tasksModel = new TasksModel
                //{
                //    TasksList = new List<TaskModel>()
                //    {
                //        new TaskModel()
                //        {
                //            Name = "Dienos užduotis 1",
                //            Priority = 0
                //        },
                //        new TaskModel()
                //        {
                //            Name = "Dienos užduotis 2",
                //            Priority = 0
                //        },
                //        new TaskModel()
                //        {
                //            Name = "Dienos užduotis 3",
                //            Priority = 0
                //        }
                //    }
                //};
            var tasksModel = new TasksModel {TasksList = new List<TaskModel>()};

                return View(tasksModel);
            }

        [HttpPost]
        public ActionResult Index(List<string> goals)
        {
            var tasksModel = new TasksModel { TasksList = new List<TaskModel>() };

            foreach (string goal in goals)
                tasksModel.TasksList.Add(new TaskModel()
                {
                    Name = goal,
                    Priority = 0
                });

           // tasksModel.TasksList.Add(new TaskModel("", 0));

            return View(tasksModel);
        }

        [HttpPost]
        public ActionResult Prepare(List<string> tasks)
        {
            var tasksModel = new TasksModel {TasksList = new List<TaskModel>()};

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

            int sequance = 0;
            var tasksDictionary = new Dictionary<int, List<TaskModel>>();
            foreach (var task in tasksModel.TasksList)
            {
                foreach (var task2 in tasksModel.TasksList)
                {
                    
                    if (task != task2)
                    {
                        // adding first pair
                        if (tasksDictionary.Count == 0)
                        {
                            var tasksPair = new List<TaskModel> { task, task2 };
                            tasksDictionary.Add(sequance, tasksPair);
                            sequance++;
                        }

                        // if task pair not already exist in dictionary, add all task pairs after first
                        bool pairExist = false;
                        foreach (var existingTasksPair in tasksDictionary.Values)
                        {
                            if (existingTasksPair.Contains(task) && existingTasksPair.Contains(task2))
                                pairExist = true;
                        }

                        if (pairExist == false)
                        {
                            var tasksPair = new List<TaskModel> { task, task2 };
                            tasksDictionary.Add(sequance, tasksPair);
                            sequance++;
                        }
                    }
                }
            }

            TempData["tasks"] = tasksDictionary;
            return View("Prioritize", tasksDictionary.First());
        }

        public ActionResult Prioritize(int sequance, string taskName)
        {
            var tasksDictionary = (Dictionary<int, List<TaskModel>>) TempData["tasks"];
            tasksDictionary[sequance].First(t => t.Name == taskName).Priority++;
            TempData["tasks"] = tasksDictionary;

            if ( tasksDictionary.Max(t => t.Key) == sequance)
                return RedirectToAction("List");

            sequance++;
            return View("Prioritize", tasksDictionary.First(t => t.Key == sequance));
        }

        public ActionResult List()
        {
            var tasksDictionary = (Dictionary<int, List<TaskModel>>)TempData["tasks"];
            var model = new TasksModel();

            foreach (var taskList in tasksDictionary.Values)
            {
                foreach (var task in taskList)
                {
                    if (model.TasksList.Contains(task))
                    {
                        model.TasksList.First(t => t.Name == task.Name).Priority += task.Priority;
                    }
                    else
                    {
                        model.TasksList.Add(task);
                    }
                }
            }

            TempData["tasks"] = tasksDictionary;
            return View("List", model);
        }
	}
}