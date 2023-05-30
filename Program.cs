using dotNetStudy.Data;
using dotNetStudy.TestClass;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// UserService�� ���� �����̳ʿ� ���
builder.Services.AddScoped<TestUserService>();

builder.Services.AddDbContext<AriaContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (builder.Configuration.GetValue<bool>("UseHttpsRedirection")) // UseHttpsRedirection ���� ���� Ȯ��
{
    app.UseHttpsRedirection(); // ���� ���� true�� ���� HTTPS �����̷��� ���
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
