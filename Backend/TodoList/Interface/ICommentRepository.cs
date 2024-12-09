using System;
using TodoList.Models;

namespace TodoList.Interface;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();
    Task<Comment?> GetByIdAsync(int id);
    Task<Comment> CreateAsync(Comment commentModel);
    Task<Comment?> UpdateAsync(int id, Comment commentModel);
    Task<Comment?> DeleteAsync(int id);
}
