using System;
using Microsoft.AspNetCore.Mvc;
using TodoList.DTOs.comment;
using TodoList.Interface;
using TodoList.Mappers;

namespace TodoList.Controllers;

[Route("TodoList/Comments")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _CommentRepo;
    private readonly ITasksRepository _TasksRepo;

    public CommentController(ICommentRepository CommentRepo, ITasksRepository TasksRepo)
    {
        _CommentRepo = CommentRepo;
        _TasksRepo = TasksRepo;
    }
    //--------------------------------------------------------------------------------------
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _CommentRepo.GetAllAsync();
        var commentsDto = comments.Select(s => s.ToCommentDto());
        return Ok(commentsDto);
    }
    //--------------------------------------------------------------------------------------
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var comment = await _CommentRepo.GetByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        return Ok(comment.ToCommentDto());
    }
    //--------------------------------------------------------------------------------------
    [HttpPost("{TasksId}")]
    public async Task<IActionResult> Create([FromRoute] int TasksId, CommentDto commentDto)
    {
        if (!await _TasksRepo.TaskExist(TasksId))
        {
            return BadRequest("User does not exist");
        }
        var commentModel = commentDto.FromCommentDto(TasksId);
        await _CommentRepo.CreateAsync(commentModel);
        return CreatedAtAction(nameof(GetById), new { id = commentModel.TasksID }, commentModel.ToCommentDto());
    }
    //--------------------------------------------------------------------------------------
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CommentDto commentDto)
    {
        var commentModel = await _CommentRepo.UpdateAsync(id, commentDto.FromCommentDto(id));
        if (commentModel == null) { return NotFound(); }
        return Ok(commentModel.ToCommentDto());
    }
    //--------------------------------------------------------------------------------------
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var commentModel = await _CommentRepo.DeleteAsync(id);
        if (commentModel == null) { return NotFound(); }
        return NoContent();
    }
    //--------------------------------------------------------------------------------------

}
