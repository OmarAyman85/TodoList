using System;

namespace TodoList.DTOs.comment;

public class CommentDto
{
    public int CommentID { get; set; }
    public int TaskID { get; set; }
    public int UserID { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
