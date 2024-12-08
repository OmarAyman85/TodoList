using System;
using Microsoft.EntityFrameworkCore;
using TodoList.ApplicationDBContext;
using TodoList.Interface;
using TodoList.Models;

namespace TodoList.Repository;

public class TasksRepository : ITasksRepository
{   
    private readonly ApplicationDbContext _DbContext;
    public TasksRepository(ApplicationDbContext DbContext)
    {
        _DbContext = DbContext;
    }
    public async Task<List<Tasks>> GetAllAsync()
    {
        return await _DbContext.Tasks.ToListAsync();
    }
}
