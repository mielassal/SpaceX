using Microsoft.Extensions.Options;

namespace SpaceXLaunchAPI.Middleware;

public class CorsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string[] _allowedOrigins;

    public CorsMiddleware(RequestDelegate next, IOptions<CorsOptions> corsOptions)
    {
        _next = next;
        _allowedOrigins = corsOptions.Value?.AllowedOrigins ?? Array.Empty<string>();
    }

    public async Task Invoke(HttpContext context)
    {
        if (_allowedOrigins.Length > 0)
        {
            string origin = context.Request.Headers["Origin"]!;

            if (_allowedOrigins.Contains(origin))
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", origin);
                context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
                context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
            }
        }

        await _next(context);
    }
}