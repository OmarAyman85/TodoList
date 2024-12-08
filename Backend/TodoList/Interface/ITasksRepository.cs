using System;
using TodoList.Models;

namespace TodoList.Interface;

public interface ITasksRepository
{
    Task<List<Tasks>> GetAllAsync();
}