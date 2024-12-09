using System;
using TodoList.DTOs.Tasks;
using TodoList.Models;

namespace TodoList.Interface;

public interface ITasksRepository
{
    Task<List<Tasks>> GetAllAsync();
    Task<Tasks?> GetByIdAsync(int id);
    Task<Tasks> CreateAsync(Tasks tasksModel);
    Task<Tasks?> UpdateAsync(int id, Tasks tasksModel);
    Task<Tasks?> DeleteAsync(int id);
    Task<bool> TaskExist(int id);
}
