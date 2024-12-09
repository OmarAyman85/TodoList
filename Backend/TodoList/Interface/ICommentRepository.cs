using System;
using TodoList.Models;

namespace TodoList.Interface;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();
    Task<Comment?> GetByIdAsync(int id);
    
}
