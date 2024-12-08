using System;
using Microsoft.AspNetCore.Mvc;
using TodoList.Interface;
using TodoList.Mappers;

namespace TodoList.Controllers;

[Route("TodoList/Users")]
[ApiController]
public class Usercontroller : ControllerBase
{
    private readonly IUserRepository _UserRepo;
    public Usercontroller(IUserRepository UserRepo)
    {
        _UserRepo = UserRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _UserRepo.GetAllAsync();
        var userDto = users.Select(s => s.ToUserDto());
        return Ok(userDto);
    }
}
