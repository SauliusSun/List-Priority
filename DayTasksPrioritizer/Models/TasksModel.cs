using System.Collections.Generic;

namespace DayTasksPrioritizer.Models
{
    public class TasksModel
    {
        public List<TaskModel> TasksList { get; set; }

        public TasksModel()
        {
            TasksList = new List<TaskModel>();
        }
    }
}