using dotNetStudy.Data;
using dotNetStudy.Services;
using dotNetStudy.TestClass;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ���� �����̳ʿ� ������ ����մϴ�.
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 

// Ŭ������ �ν��Ͻ��� ���� �����̳ʿ� ����մϴ�.
builder.Services.AddScoped<TestUserService>(); 
builder.Services.AddScoped<UserService>(); 
builder.Services.AddScoped<AvatarService>();

// AriaContext�� DbContext�� ����ϰ�, MySQL �����ͺ��̽��� ����ϵ��� �����մϴ�.
builder.Services.AddDbContext<AriaContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // ���� ȯ�濡�� Swagger�� ����Ͽ� API ������ �����մϴ�.
    app.UseSwaggerUI(); // Swagger UI�� ���� ������ �ð�ȭ�ϰ� �˻��� �� �ֽ��ϴ�.
}

if (builder.Configuration.GetValue<bool>("UseHttpsRedirection")) // UseHttpsRedirection ���� ���� Ȯ��
{
    app.UseHttpsRedirection(); // ���� ���� true�� ���� HTTPS �����̷��� ���
}

app.UseRouting(); // ������� ���� �̵��� ����մϴ�.
app.UseAuthorization(); // ������ ���� �̵��� ����մϴ�.
app.MapControllers(); // ��ϵ� ��Ʈ�ѷ��� ��û�� �����մϴ�.
app.Run();
