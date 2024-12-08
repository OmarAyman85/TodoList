using System;
using TodoList.DTOs.comment;
using TodoList.Models;

namespace TodoList.Mappers;

public static class CommentMapper
{
    public static CommentDto ToCommentDto(this Comment CommentModel)
    {
        return new CommentDto{
            CommentID = CommentModel.CommentID,
            TaskID = CommentModel.TaskID,
            UserID = CommentModel.UserID,
            Content = CommentModel.Content,
            CreatedAt = CommentModel.CreatedAt
        };
    }
}
