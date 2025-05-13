using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        TaskManager manager = new TaskManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Task Manager ---");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": manager.AddTask(); break;
                case "2": manager.ViewTasks(); break;
                case "3": manager.MarkCompleted(); break;
                case "4": manager.DeleteTask(); break;
                case "5": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}

class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}

class TaskManager
{
    private List<Task> tasks = new List<Task>();
    private int idCounter = 1;

    public void AddTask()
    {
        Console.Write("Enter task description: ");
        string desc = Console.ReadLine();
        tasks.Add(new Task { Id = idCounter++, Description = desc, IsCompleted = false });
        Console.WriteLine("Task added.");
    }

    public void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id}. [{(task.IsCompleted ? "✔" : " ")}] {task.Description}");
        }
    }

    public void MarkCompleted()
    {
        Console.Write("Enter task ID to mark complete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
                Console.WriteLine("Task marked as completed.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
    }

    public void DeleteTask()
    {
        Console.Write("Enter task ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            int removed = tasks.RemoveAll(t => t.Id == id);
            Console.WriteLine(removed > 0 ? "Task deleted." : "Task not found.");
        }
    }
}
