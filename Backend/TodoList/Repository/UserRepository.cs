using System;
using Microsoft.EntityFrameworkCore;
using TodoList.ApplicationDBContext;
using TodoList.DTOs.user;
using TodoList.DTOs.Users;
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
        return await _DbContext.User.Include(c => c.Tasks).ThenInclude(x => x.Comments).ToListAsync();
    }
    //----------------------------------------------------------------------------------------------------
    public async Task<User?> GetByIdAsync(int id)
    {
        return await _DbContext.User.Include(c => c.Tasks).ThenInclude(x => x.Comments).FirstOrDefaultAsync(i => i.UserID == id);
    }
    //----------------------------------------------------------------------------------------------------
    public async Task<User> CreateAsync(User UserModel)
    {
        await _DbContext.User.AddAsync(UserModel);
        await _DbContext.SaveChangesAsync();
        return UserModel;
    }
    //----------------------------------------------------------------------------------------------------
    public async Task<User?> UpdateAsync(int id, UpdateUserDto UserDto)
    {
        var existingUser = await _DbContext.User.FirstOrDefaultAsync(x => x.UserID == id);
        if (existingUser == null) { return null; }
        existingUser.Username = UserDto.Username;
        existingUser.Email = UserDto.Email;
        existingUser.Password = UserDto.Password;
        await _DbContext.SaveChangesAsync();
        return existingUser;
    }
    //----------------------------------------------------------------------------------------------------
    public async Task<User?> DeleteAsync(int id)
    {
        var UserModel = await _DbContext.User.FirstOrDefaultAsync(x => x.UserID == id);
        if (UserModel == null) { return null; }
        _DbContext.User.Remove(UserModel);
        await _DbContext.SaveChangesAsync();
        return UserModel;
    }
    //----------------------------------------------------------------------------------------------------
    public Task<bool> UserExist(int id)
    {
        return _DbContext.User.AnyAsync(s => s.UserID == id);
    }
}
