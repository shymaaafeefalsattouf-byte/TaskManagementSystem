using System;
using System.Collections.Generic;
using System.Linq;

public class TaskRepository
{
    private readonly OurContext _context;

    public TaskRepository()
    {
        _context = new OurContext();
    }

    public bool Add(TaskItem task)
    {
        _context.TaskItems.Add(task);
        return _context.SaveChanges() > 0;
    }

    public bool Update(TaskItem task)
    {
        _context.TaskItems.Update(task);
        return _context.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        var task = _context.TaskItems.Find(id);
        if (task == null) return false;

        _context.TaskItems.Remove(task);
        return _context.SaveChanges() > 0;
    }

    public TaskItem GetById(int id)
    {
        return _context.TaskItems.Find(id);
    }

    public List<TaskItem> GetAll()
    {
        return _context.TaskItems.ToList();
    }

    public List<TaskItem> GetTasksByCategory(string category)
    {
        return _context.TaskItems.Where(t => t.Category == category).ToList();
    }

    public List<TaskItem> GetCompletedTasks()
    {
        return _context.TaskItems.Where(t => t.IsCompleted).ToList();
 
    // Get all tasks that are not completed
public List<TaskItem> GetUncompletedTasks()
{
    return _context.TaskItems
        .Where(t => !t.IsCompleted)
        .ToList();
}

// Get all overdue tasks
public List<TaskItem> GetOverdueTasks()
{
    return _context.TaskItems
        .Where(t => !t.IsCompleted && t.DueDate < DateTime.Now)
        .ToList();
}
    }
}
