using Core.Extensions;
using Core.Middlewares;
using Core.Utilities.Ioc;
using Service.Mappers;
using Service.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AdvertMapper), typeof(CategoryMapper));
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    //new CoreModule(),
    new DIModule(builder.Configuration)
});
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