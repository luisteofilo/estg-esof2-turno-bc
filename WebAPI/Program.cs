using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.WebAPI.Services;
using Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<WineService>();
builder.Services.AddScoped<GrapeTypeService>();
builder.Services.AddScoped<BrandService>();
builder.Services.AddScoped<RegionService>();
builder.Services.AddScoped<WineLeaderboardService>();
builder.Services.AddScoped<UserLeaderboardService>();

// Configurar o DbContext com a conexão ao banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var db = EnvFileHelper.GetString("POSTGRES_DB");
    var user = EnvFileHelper.GetString("POSTGRES_USER");
    var password = EnvFileHelper.GetString("POSTGRES_PASSWORD");
    var port = EnvFileHelper.GetString("POSTGRES_PORT");
    var host = EnvFileHelper.GetString("POSTGRES_HOST");

    if (string.IsNullOrEmpty(db) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password) ||
        string.IsNullOrEmpty(port) || string.IsNullOrEmpty(host))
    {
        throw new InvalidOperationException(
            "Database connection information not fully specified in environment variables.");
    }

    var connectionString = $"Host={host};Port={port};Database={db};Username={user};Password={password}";
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.Run();


/*var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.MapGet("/users/emails", () =>
    {
        var db = new ApplicationDbContext();
        return db.Users.Select(u => u.Email);
    })
    .WithName("GetUsersNames")
    .WithOpenApi();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
*/