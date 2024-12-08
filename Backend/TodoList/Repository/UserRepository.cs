using System;
using Microsoft.EntityFrameworkCore;
using TodoList.ApplicationDBContext;
using TodoList.Interface;
using TodoList.Models;

namespace TodoList.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _DbContext;
    public UserRepository(ApplicationDbContext DbContext)
    {
        _DbContext = DbContext;
    }
    public async Task<List<User>> GetAllAsync()
    {
        return await _DbContext.User.ToListAsync();
    }
}
