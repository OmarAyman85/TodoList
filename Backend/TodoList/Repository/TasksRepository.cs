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
        return await _DbContext.Tasks.Include(c => c.Comments).ToListAsync();
    }
    //----------------------------------------------------------------------------------------------------

    public async Task<Tasks?> GetByIdAsync(int id)
    {
        return await _DbContext.Tasks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.TasksID == id);
    }
    //----------------------------------------------------------------------------------------------------

    public async Task<Tasks> CreateAsync(Tasks tasksModel)
    {
        await _DbContext.Tasks.AddAsync(tasksModel);
        await _DbContext.SaveChangesAsync();
        return tasksModel;
    }
    //----------------------------------------------------------------------------------------------------

    public async Task<Tasks?> UpdateAsync(int id, Tasks tasksModel)
    {
        var existingTask = await _DbContext.Tasks.FindAsync(id);
        if (existingTask == null)
        {
            return null;
        }
        existingTask.Title = tasksModel.Title;
        existingTask.Description = tasksModel.Description;
        existingTask.Priority = tasksModel.Priority;
        await _DbContext.SaveChangesAsync();
        return existingTask;
    }
    //----------------------------------------------------------------------------------------------------

    public async Task<Tasks?> DeleteAsync(int id)
    {
        var taskModel = await _DbContext.Tasks.FirstOrDefaultAsync(x => x.TasksID == id);
        if (taskModel == null) { return null; }
        _DbContext.Tasks.Remove(taskModel);
        await _DbContext.SaveChangesAsync();
        return taskModel;
    }
    //----------------------------------------------------------------------------------------------------

    public Task<bool> TaskExist(int id)
    {
        return _DbContext.Tasks.AnyAsync(s => s.TasksID == id);
    }
}
