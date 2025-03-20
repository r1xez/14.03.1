using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoListApp
{
    
    public enum TaskStatus
    {
        NotStarted,
        InProgress,
        Completed,
        Deferred
    }

   
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }

        public Task(string title, string description, TaskStatus status)
        {
            Title = title;
            Description = description;
            Status = status;
        }

        public void ChangeStatus(TaskStatus newStatus)
        {
            Status = newStatus;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Description: {Description}, Status: {Status}";
        }
    }

    
    public class TaskManager
    {
        private List<Task> _tasks;

        public TaskManager()
        {
            _tasks = new List<Task>();
        }

       
        public void AddTask(Task task)
        {
            _tasks.Add(task);
            Console.WriteLine($"Task '{task.Title}' has been added.");
        }

        
        public void ChangeTaskStatus(string title, TaskStatus newStatus)
        {
            var task = _tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (task != null)
            {
                task.ChangeStatus(newStatus);
                Console.WriteLine($"Task '{title}' status has been updated to {newStatus}.");
            }
            else
            {
                Console.WriteLine($"Task '{title}' not found.");
            }
        }

        
        public void DisplayTasksByStatus(TaskStatus status)
        {
            var tasksByStatus = _tasks.Where(t => t.Status == status).ToList();

            if (tasksByStatus.Any())
            {
                Console.WriteLine($"Tasks with status '{status}':");
                foreach (var task in tasksByStatus)
                {
                    Console.WriteLine(task);
                }
            }
            else
            {
                Console.WriteLine($"No tasks found with status '{status}'.");
            }
        }

        
        public void ListAllTasks()
        {
            if (_tasks.Any())
            {
                Console.WriteLine("All tasks:");
                foreach (var task in _tasks)
                {
                    Console.WriteLine(task);
                }
            }
            else
            {
                Console.WriteLine("No tasks available.");
            }
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            var taskManager = new TaskManager();

          
            taskManager.AddTask(new Task("Task 1", "Description of Task 1", TaskStatus.NotStarted));
            taskManager.AddTask(new Task("Task 2", "Description of Task 2", TaskStatus.InProgress));
            taskManager.AddTask(new Task("Task 3", "Description of Task 3", TaskStatus.Completed));

           
            while (true)
            {
                Console.WriteLine("\nTo-Do List Management");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Change Task Status");
                Console.WriteLine("3. Display Tasks by Status");
                Console.WriteLine("4. List All Tasks");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter task title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter task description: ");
                        string description = Console.ReadLine();
                        taskManager.AddTask(new Task(title, description, TaskStatus.NotStarted));
                        break;

                    case "2":
                        Console.Write("Enter task title to change status: ");
                        string taskTitle = Console.ReadLine();
                        Console.WriteLine("Select new status:");
                        Console.WriteLine("0 - NotStarted");
                        Console.WriteLine("1 - InProgress");
                        Console.WriteLine("2 - Completed");
                        Console.WriteLine("3 - Deferred");
                        Console.Write("Enter status: ");
                        int statusChoice;
                        if (int.TryParse(Console.ReadLine(), out statusChoice) && Enum.IsDefined(typeof(TaskStatus), statusChoice))
                        {
                            taskManager.ChangeTaskStatus(taskTitle, (TaskStatus)statusChoice);
                        }
                        else
                        {
                            Console.WriteLine("Invalid status choice.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Select status to display tasks:");
                        Console.WriteLine("0 - NotStarted");
                        Console.WriteLine("1 - InProgress");
                        Console.WriteLine("2 - Completed");
                        Console.WriteLine("3 - Deferred");
                        Console.Write("Enter status: ");
                        if (int.TryParse(Console.ReadLine(), out statusChoice) && Enum.IsDefined(typeof(TaskStatus), statusChoice))
                        {
                            taskManager.DisplayTasksByStatus((TaskStatus)statusChoice);
                        }
                        else
                        {
                            Console.WriteLine("Invalid status choice.");
                        }
                        break;

                    case "4":
                        taskManager.ListAllTasks();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
