using System;

namespace TodoList.Models;

public class Tasks
{
    public int TasksID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; } = DateTime.Now;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int UserID { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime CompletedAt { get; set; } = DateTime.Now;
    public List<Comment> Comments {get; set;} = new List<Comment>();
}
