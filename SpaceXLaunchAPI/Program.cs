using SpaceXLaunchAPI.Endpoints;
using SpaceXLaunchAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CorsOptions>(builder.Configuration.GetSection("Cors"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCorsMiddleware();

app.MapGet("/Launch/{id}", async (string id) => await EndpointsAccessor.GetLaunch(id));

app.Run();




