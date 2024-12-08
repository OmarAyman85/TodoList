using System;
using Microsoft.AspNetCore.Mvc;
using TodoList.Interface;
using TodoList.Mappers;

namespace TodoList.Controllers;

[Route("TodoList/Comments")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _CommentRepo;

    public CommentController(ICommentRepository CommentRepo)
    {
        _CommentRepo = CommentRepo;
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
        if(comment == null){
            return NotFound();
        }
        return Ok(comment.ToCommentDto());
    }
//--------------------------------------------------------------------------------------

}
