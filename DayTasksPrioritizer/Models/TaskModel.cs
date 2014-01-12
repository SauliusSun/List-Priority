namespace DayTasksPrioritizer.Models
{
    public class TaskModel
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public TaskModel()
        {
        }

        public TaskModel(string name, int priority)
        {
            this.Name = name;
            this.Priority = priority;
        }
    }
}