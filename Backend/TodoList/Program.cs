using Microsoft.EntityFrameworkCore;
using TodoList.ApplicationDBContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();