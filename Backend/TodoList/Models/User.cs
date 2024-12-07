using System;
using Microsoft.VisualBasic;

namespace TodoList.Models;

public class User
{
    public int UserID { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password  { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } 
    
}
