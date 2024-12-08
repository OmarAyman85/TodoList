using System;
using Microsoft.Extensions.Configuration.UserSecrets;
using TodoList.DTOs.user;
using TodoList.Models;

namespace TodoList.Mappers;

public static class UserMapper
{
    public static UserDto ToUserDto(this User UserModel)
    {
        return new UserDto{
        UserID = UserModel.UserID,
        Username = UserModel.Username,
        Email = UserModel.Email,
        Password = UserModel.Password,
        CreatedAt = UserModel.CreatedAt
        };
    }
}
