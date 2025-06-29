using FlagStorm.Data.Interfaces.Service;
using FlagStorm.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


public static class ApiHost
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<IFeatureService, FeatureService>();
        services.AddControllers();
        return services;
    }
}