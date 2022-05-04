using System.Data;
using System.Reflection;
using Core.Middlewares;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Npgsql;
using Service.Abstract;
using Service.Concrete;
using Service.Mappers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDbConnection>(sp
    => new NpgsqlConnection(builder.Configuration.GetConnectionString("PostgreSql")));
builder.Services.AddAutoMapper(typeof(Mapper));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseGlobalExceptionMiddleware();
app.Run();