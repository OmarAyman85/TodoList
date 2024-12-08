using System;
using TodoList.DTOs.user;
using TodoList.Models;

namespace TodoList.Interface;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User> CreateAsync(User UserModel);
    Task<User?> UpdateAsync (int id, UserDto userDto);
    Task<User?> DeleteAsync(int id);
}
