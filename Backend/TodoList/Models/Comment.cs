using System;

namespace TodoList.Models;

public class Comment
{
    public int CommentID { get; set; }
    public int TaskID { get; set; }
    public int UserID { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

}
