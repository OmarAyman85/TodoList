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

    public static Tasks FromTasksDto(this TasksDto tasksDto, int UserId)
    {
        return new Tasks
        {
            TasksID = tasksDto.TasksID,
            Title = tasksDto.Title,
            Description = tasksDto.Description,
            DueDate = tasksDto.DueDate,
            Priority = tasksDto.Priority,
            Status = tasksDto.Status,
            UserID = UserId,
            CreatedAt = tasksDto.CreatedAt,
            UpdatedAt = tasksDto.UpdatedAt,
            CompletedAt = tasksDto.CompletedAt
        };
    }
}
