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
    public async Task<List<Comment>> GetAllAsync()
    {
        return await _DbContext.Comment.ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _DbContext.Comment.FindAsync(id);
    }
}
