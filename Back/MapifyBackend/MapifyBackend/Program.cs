using MapifyBackend.database_files;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Initialize db
DatabaseInitializer.EnsureDatabaseCreated();

// Register services
builder.Services.AddSingleton<DatabaseService>(); // One for all time
builder.Services.AddScoped<StratService>();     // Gets created for each request

// add Cors and controllers support
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// 4. Middleware
app.UseCors("AllowAll");
app.MapControllers(); // Connects URL with controllers

// Run server
app.Run();