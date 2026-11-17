using System;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public string Priority { get; set; }
    public DateTime PlannedDate { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}
