using System.Text.Json;

namespace AssistHub.Backend.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            var message = new
            {
                Name = "Something went wrong.",
                StatusCode = 500,
            };
            await using var memoryStream = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(message));
            await memoryStream.CopyToAsync(context.Response.Body);
        }
    }
}