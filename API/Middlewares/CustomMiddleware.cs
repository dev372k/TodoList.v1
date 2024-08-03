using API.Models;
using System.Net;

namespace API.Middlewares;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;
    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            var key = "644741f7-76db-457d-91e8-042e00bd8245";

            var apiKey = context.Request.Headers["X-API-KEY"].ToString();
            if (apiKey == key)
                await _next(context);

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        catch (Exception ex)
        {
            await context.Response.WriteAsJsonAsync(new ResponseModel
            {
                Status = false,
                Message = ex.Message
            });
        }
    }
}
