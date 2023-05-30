using dotNetStudy.Data;
using dotNetStudy.Services;
using dotNetStudy.TestClass;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 서비스 컨테이너에 설정을 등록합니다.
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 

// 클래스의 인스턴스를 서비스 컨테이너에 등록합니다.
builder.Services.AddScoped<TestUserService>(); 
builder.Services.AddScoped<UserService>(); 
builder.Services.AddScoped<AvatarService>();

// AriaContext를 DbContext로 등록하고, MySQL 데이터베이스를 사용하도록 구성합니다.
builder.Services.AddDbContext<AriaContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // 개발 환경에서 Swagger를 사용하여 API 문서를 노출합니다.
    app.UseSwaggerUI(); // Swagger UI를 통해 문서를 시각화하고 검색할 수 있습니다.
}

if (builder.Configuration.GetValue<bool>("UseHttpsRedirection")) // UseHttpsRedirection 설정 값을 확인
{
    app.UseHttpsRedirection(); // 설정 값이 true일 때만 HTTPS 리다이렉션 사용
}

app.UseRouting(); // 라우팅을 위한 미들웨어를 등록합니다.
app.UseAuthorization(); // 인증을 위한 미들웨어를 등록합니다.
app.MapControllers(); // 등록된 컨트롤러를 요청에 매핑합니다.
app.Run();
