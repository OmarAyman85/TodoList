using System;

namespace TodoList.DTOs.Comment;

public class CreateCommentDto
{
    public string Content { get; set; } = string.Empty;
}