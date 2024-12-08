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
        CreatedAt = UserModel.CreatedAt,
        Tasks = UserModel.Tasks.Select(c => c.ToTasksDto()).ToList()
        };
    }

    public static User FromUserDto(this UserDto userDto){
        return new User{
            UserID = userDto.UserID,
            Username = userDto.Username,
            Email = userDto.Email,
            Password = userDto.Password,
            CreatedAt = userDto.CreatedAt,
        };
    }
}
