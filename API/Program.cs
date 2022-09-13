using Core.CrossCuttingConcerns.Exceptions;
using Core.Extensions;
using Core.Middlewares;
using Core.Utilities.Ioc;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Service.Mappers;
using Service.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AdvertMapper), typeof(CategoryMapper),typeof(OperationClaimMapper));

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthenticationJWT(tokenOptions);

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

app.ConfigureCustomExceptionMiddleware();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// app.UseGlobalExceptionMiddleware();
app.Run();