using System;
using Microsoft.VisualBasic;

namespace TodoList.Models;

public class User
{
    public int UserID { get; set; }
    public string UUsername { get; set; } = string.Empty;
    public string EEmail { get; set; } = string.Empty;
    public string PPassword  { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } 
    public List<Tasks> Tasks {get; set;} = new List<Tasks>();
    
}
