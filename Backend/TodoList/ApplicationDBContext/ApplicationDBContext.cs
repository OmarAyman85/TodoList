using System;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.ApplicationDBContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public required DbSet<User> User { get; set; }
    public required DbSet<Tasks> Tasks { get; set; }
    public required DbSet<Comment> Comment { get; set; }
}
