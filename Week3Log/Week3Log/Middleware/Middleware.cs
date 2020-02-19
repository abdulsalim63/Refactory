using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Week3Log.Models;
using System.IO;

namespace Week3Log.Middleware
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            await _next(context);
            Console.WriteLine(context.Response.StatusCode);
            if (context.Response.StatusCode == 404)
            {
                File.AppendAllText("/Users/gigaming/Downloads/Refactory Image/Training/Refactory Task/Week3Log/Week3Log/app.log",
                    $"Started {context.Request.Method} {context.Request.Path} for {context.Request.Host}\n");
                File.AppendAllText("/Users/gigaming/Downloads/Refactory Image/Training/Refactory Task/Week3Log/Week3Log/app.log",
                    $"Completed {context.Response.StatusCode} {context.Request.Path} not found for {context.Request.Path}\n\n");
            }
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}
