using System;

namespace TodoList.DTOs.comment;

public class CommentDto
{
    public int CommentID { get; set; }
    public int TasksID { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
