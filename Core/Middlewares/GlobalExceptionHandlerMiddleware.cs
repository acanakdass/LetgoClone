using System.Text.Json;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Core.Middlewares;

public static class GlobalExceptionHandlerMiddleware
{
    public static void UseGlobalExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(options =>
        {
            options.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                var exception = exceptionFeature.Error;
                context.Response.StatusCode=
                context.Response.StatusCode = 500;
                var erResult = new ErrorResult(exception.Message);
                var responseBody = JsonSerializer.Serialize(erResult);
                await context.Response.WriteAsync(responseBody);
            });
        });
    }
}