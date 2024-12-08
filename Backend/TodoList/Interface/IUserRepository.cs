using System;
using TodoList.Models;

namespace TodoList.Interface;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
}