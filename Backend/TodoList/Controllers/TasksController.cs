using System;
using Microsoft.AspNetCore.Mvc;
using TodoList.Interface;
using TodoList.Mappers;

namespace TodoList.Controllers;

[Route("TodoList/Tasks")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ITasksRepository _TasksRepo;
    public TasksController(ITasksRepository TasksRepo)
    {
        _TasksRepo = TasksRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _TasksRepo.GetAllAsync();
        var tasksDto = tasks.Select(s => s.ToTasksDto());
        return Ok(tasksDto);
    }


}
