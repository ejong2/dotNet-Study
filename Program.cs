using dotNetStudy.Data;
using dotNetStudy.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserService>();

builder.Services.AddDbContext<AriaContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11))));

var app = builder.Build();

// Add the following lines:
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AriaContext>();
        context.Database.Migrate(); // Apply migrations at runtime
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (builder.Configuration.GetValue<bool>("UseHttpsRedirection")) // UseHttpsRedirection 설정 값을 확인
{
    app.UseHttpsRedirection(); // 설정 값이 true일 때만 HTTPS 리다이렉션 사용
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
