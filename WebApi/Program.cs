using Infrastructure;
using Infrastructure.AutoMapper;
using Infrastructure.Data;
using Infrastructure.Services.StudentServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var con = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(c=>c.UseNpgsql(con));
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
