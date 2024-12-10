using System;
using Microsoft.AspNetCore.Mvc;
using TodoList.DTOs.Tasks;
using TodoList.Interface;
using TodoList.Mappers;

namespace TodoList.Controllers;

[Route("TodoList/Tasks")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ITasksRepository _TasksRepo;
    private readonly IUserRepository _UserRepo;
    public TasksController(ITasksRepository TasksRepo, IUserRepository UserRepo)
    {
        _TasksRepo = TasksRepo;
        _UserRepo = UserRepo;
    }
    //--------------------------------------------------------------------------------------
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _TasksRepo.GetAllAsync();
        var tasksDto = tasks.Select(s => s.ToTasksDto());
        return Ok(tasksDto);
    }
    //--------------------------------------------------------------------------------------    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tasks = await _TasksRepo.GetByIdAsync(id);
        if (tasks == null)
        {
            return NotFound();
        }
        return Ok(tasks.ToTasksDto());
    }
    //--------------------------------------------------------------------------------------
    [HttpPost("{UserId}")]
    public async Task<IActionResult> Create([FromRoute] int UserId, CreateTaskDto tasksDto)
    {
        if (!await _UserRepo.UserExist(UserId)) { return BadRequest("User does not exist");}
        var taskModel = tasksDto.FromCreateTasksDto(UserId);
        await _TasksRepo.CreateAsync(taskModel);
        return CreatedAtAction(nameof(GetById), new { id = taskModel.UserID }, taskModel.ToTasksDto());
    }
    //--------------------------------------------------------------------------------------
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTaskDto taskDto)
    {
        var task = await _TasksRepo.UpdateAsync(id, taskDto.FromUpdateTasksDto());
        if (task == null) { return NotFound("Task is not found"); }
        return Ok(task.ToTasksDto());
    }
    //--------------------------------------------------------------------------------------
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var taskModel = await _TasksRepo.DeleteAsync(id);
        if (taskModel == null) { return NotFound(); }
        return NoContent();
    }
    //--------------------------------------------------------------------------------------

}
