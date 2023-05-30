using dotNetStudy.Data;
using dotNetStudy.TestClass;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// UserService를 서비스 컨테이너에 등록
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

if (builder.Configuration.GetValue<bool>("UseHttpsRedirection")) // UseHttpsRedirection 설정 값을 확인
{
    app.UseHttpsRedirection(); // 설정 값이 true일 때만 HTTPS 리다이렉션 사용
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
