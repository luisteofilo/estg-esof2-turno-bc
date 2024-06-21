using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using ESOF.WebApp.WebAPI.Services;
using Helpers.ViewModels;

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
builder.Services.AddDbContext<ApplicationDbContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
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

app.MapGet("/feed/getposts", () =>
    {
        var db = new ApplicationDbContext();
        var postsList = new PostsList()
        {
            Lines = db.Posts.Select(p => new PostsListLine()
            {
                CreatorId = p.CreatorId,
                Text = p.Text ?? ""
            }).ToList()
        };
        foreach (var p in postsList.Lines)
        {
            var user = db.Users.Find(p.CreatorId);
            p.Creator = new PostsUser()
            {
                email = user.Email
            };
        }
        return postsList;
    })
    .WithName("GetAllPosts")
    .WithOpenApi();

app.MapGet("/deleteaccess/allpostshares", () =>
    {
        var db = new ApplicationDbContext();
        Guid postId = new Guid();
        Post post = db.Posts.Find(postId);
        Guid userId = post.CreatorId;
        return db.PostUserShare.Where(p => p.SharedPostId == postId && p.UserSentId == userId);
    })
    .WithName("GetAllSharesOfPostFromCreator")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
*/