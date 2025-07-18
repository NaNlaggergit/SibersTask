using Microsoft.EntityFrameworkCore;
using System;
using SibersTask.Infrastructure.Data;
using SibersTask.BusinessLogic.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .EnableSensitiveDataLogging() // Показывает параметры в логах
        .LogTo(Console.WriteLine, LogLevel.Information)
        );
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.WithOrigins("https://localhost:7022", "http://localhost:5002") // адреса твоего Blazor фронта
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<EmployeeService>();
// Add services to the container.
 
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowBlazorClient");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
