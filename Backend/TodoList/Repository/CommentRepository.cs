using System;
using Microsoft.EntityFrameworkCore;
using TodoList.ApplicationDBContext;
using TodoList.Interface;
using TodoList.Models;

namespace TodoList.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _DbContext;
    public CommentRepository(ApplicationDbContext DbContext)
    {
        _DbContext = DbContext;
    }
    //----------------------------------------------------------------------------------------------------

    public async Task<List<Comment>> GetAllAsync()
    {
        return await _DbContext.Comment.ToListAsync();
    }
    //----------------------------------------------------------------------------------------------------

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _DbContext.Comment.FirstOrDefaultAsync(i => i.CommentID == id);
    }
    //----------------------------------------------------------------------------------------------------

    public async Task<Comment> CreateAsync(Comment commentModel)
    {
        await _DbContext.Comment.AddAsync(commentModel);
        await _DbContext.SaveChangesAsync();
        return commentModel;
    }
    //----------------------------------------------------------------------------------------------------

    public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
    {
        var existingComment = await _DbContext.Comment.FindAsync(id);
        if (existingComment == null) { return null; }
        existingComment.CommentID = commentModel.CommentID;
        existingComment.UserID = commentModel.UserID;
        existingComment.TasksID = commentModel.TasksID;
        existingComment.Content = commentModel.Content;
        existingComment.CreatedAt = commentModel.CreatedAt;
        await _DbContext.SaveChangesAsync();
        return existingComment;
    }
    //----------------------------------------------------------------------------------------------------

    public async Task<Comment?> DeleteAsync(int id)
    {
        var commentModel = await _DbContext.Comment.FirstOrDefaultAsync(x => x.CommentID == id);
        if (commentModel == null) { return null; }
        _DbContext.Comment.Remove(commentModel);
        await _DbContext.SaveChangesAsync();
        return commentModel;
    }
}
