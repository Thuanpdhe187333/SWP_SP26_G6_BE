using Microsoft.EntityFrameworkCore;
using CoreHR.Models; // Đảm bảo tên này khớp với Namespace trong folder Models

var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký DbContext (Lấy chuỗi kết nối từ appsettings.json)
builder.Services.AddDbContext<HrmSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Cấu hình CORS để gọi sang Frontend sau này
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();