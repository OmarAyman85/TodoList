using System;
using TodoList.DTOs.Tasks;

namespace TodoList.DTOs.user;

public class UserDto
{

    public int UserID { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<TasksDto> Tasks {get; set;} 
}
