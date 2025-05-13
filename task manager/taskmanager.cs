using System;
using System.Collections.Generic;

public class TaskManager
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
        int id = int.Parse(Console.ReadLine());
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

    public void DeleteTask()
    {
        Console.Write("Enter task ID to delete: ");
        int id = int.Parse(Console.ReadLine());
        tasks.RemoveAll(t => t.Id == id);
        Console.WriteLine("Task deleted if it existed.");
    }
}
