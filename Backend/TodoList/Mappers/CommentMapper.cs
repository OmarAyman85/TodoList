using System;
using TodoList.DTOs.comment;
using TodoList.DTOs.Comment;
using TodoList.Models;

namespace TodoList.Mappers;

public static class CommentMapper
{
    //--------------------------------------------------------------------------------------------
    public static CommentDto ToCommentDto(this Comment CommentModel)
    {
        return new CommentDto
        {
            CommentID = CommentModel.CommentID,
            TasksID = CommentModel.TasksID,
            Content = CommentModel.Content,
            CreatedAt = CommentModel.CreatedAt
        };
    }
    //--------------------------------------------------------------------------------------------
    public static Comment FromCommentDto(this CommentDto commentDto, int tasksID)
    {
        return new Comment
        {
            CommentID = commentDto.CommentID,
            TasksID = tasksID,
            Content = commentDto.Content,
            CreatedAt = commentDto.CreatedAt
        };
    }
    //--------------------------------------------------------------------------------------------
    public static Comment FromCreateCommentDto(this CreateCommentDto commentDto, int tasksID)
    {
        return new Comment
        {
            TasksID = tasksID,
            Content = commentDto.Content
        };
    }
    //--------------------------------------------------------------------------------------------
        public static Comment FromUpdateCommentDto(this UpdateCommentDto commentDto)
    {
        return new Comment
        {
            Content = commentDto.Content
        };
    }
}
