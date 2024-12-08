using System;
using Microsoft.AspNetCore.Mvc;
using TodoList.DTOs.user;
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
    //--------------------------------------------------------------------------------------
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _UserRepo.GetAllAsync();
        var userDto = users.Select(s => s.ToUserDto());
        return Ok(userDto);
    }
    //--------------------------------------------------------------------------------------
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var user = await _UserRepo.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    //--------------------------------------------------------------------------------------
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDto userDto)
    {
        var userModel = userDto.FromUserDto();
        await _UserRepo.CreateAsync(userModel);
        return CreatedAtAction(nameof(GetById), new { id = userModel.UserID }, userModel.ToUserDto());
    }
    //--------------------------------------------------------------------------------------
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserDto userDto)
    {
        var userModel = await _UserRepo.UpdateAsync(id, userDto);
        if (userModel == null) { return NotFound(); }
        return Ok(userModel.ToUserDto());
    }
    //--------------------------------------------------------------------------------------
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var userModel = await _UserRepo.DeleteAsync(id);
        if (userModel == null) { return NotFound(); }
        return NoContent();
    }
}
