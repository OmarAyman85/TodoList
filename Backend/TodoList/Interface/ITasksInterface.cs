using System;
using TodoList.Models;

namespace TodoList.Interface;

public interface ITasksInterface
{
    Task<List<Tasks>> GetAllAsync();
}
