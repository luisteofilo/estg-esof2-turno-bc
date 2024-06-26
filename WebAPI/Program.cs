using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<WineService>();
builder.Services.AddScoped<GrapeTypeService>();
builder.Services.AddScoped<BrandService>();
builder.Services.AddScoped<RegionService>();

builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<FriendshipService>();
builder.Services.AddScoped<FriendRequestService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<LikeService>();
builder.Services.AddDbContext<ApplicationDbContext>();


builder.Services.AddScoped<TasteEvaluationService>();
builder.Services.AddScoped<TasteEvaluationQuestionService>();
builder.Services.AddScoped<TasteQuestionService>();
builder.Services.AddScoped<TasteQuestionTypeService>();

builder.Services.AddScoped<InteractionService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:5297")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
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

=======
