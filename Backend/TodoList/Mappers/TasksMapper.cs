using System;
using TodoList.DTOs.Tasks;
using TodoList.Models;

namespace TodoList.Mappers;

public static class TasksMapper
{
    public static TasksDto ToTasksDto(this Tasks TasksModel)
    {
        return new TasksDto
        {
            TasksID = TasksModel.TasksID,
            Title = TasksModel.Title,
            Description = TasksModel.Description,
            DueDate = TasksModel.DueDate,
            Priority = TasksModel.Priority,
            Status = TasksModel.Status,
            UserID = TasksModel.UserID,
            CreatedAt = TasksModel.CreatedAt,
            UpdatedAt = TasksModel.UpdatedAt,
            CompletedAt = TasksModel.CompletedAt,
            Comments = TasksModel.Comments.Select(c => c.ToCommentDto()).ToList()
        };
    }
}
