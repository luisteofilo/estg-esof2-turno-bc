using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



var summaries = new[]
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


app.MapGet("/usersdois", () =>
    {
        var db = new ApplicationDbContext();
        return db.Users.Select(u => new { u.UserId, u.Email }).ToList();
    })
    .WithName("GetUsersDois")
    .WithOpenApi();



app.MapGet("/vinho", () =>
    {
        var db = new ApplicationDbContext();
        return db.Vinho.Select(u => new { u.VinhoId, u.Name, u.Tipo }).ToList();
    })
    .WithName("GetVinho")
    .WithOpenApi();

app.MapPost("/create-interaction", async (Interacao interactionRequest) =>
    {
        var db = new ApplicationDbContext();
        
        var user = await db.Users.FindAsync(interactionRequest.user_id);
        var vinho = await db.Vinho.FindAsync(interactionRequest.vinho_id);
    
        if (user == null || vinho == null)
        {
            return Results.NotFound();
        }

        var interaction = new Interacao
        {
            user_id = interactionRequest.user_id,
            vinho_id = interactionRequest.vinho_id,
            tipo_interacao = interactionRequest.tipo_interacao,
            User = user,
            Vinho = vinho
        };

        db.Interacao.Add(interaction);
        await db.SaveChangesAsync();
    
        return Results.Ok();
    })
    .WithName("CreateInteraction")
    .WithOpenApi();

app.MapPut("/update-interaction", async (Interacao interactionUpdate) =>
    {
        var db = new ApplicationDbContext();
        var interaction = db.Interacao.FirstOrDefault(i => i.user_id == interactionUpdate.user_id && i.vinho_id == interactionUpdate.vinho_id);
        if (interaction == null)
        {
            return Results.NotFound();
        }
        
        interaction.tipo_interacao = interactionUpdate.tipo_interacao;
        await db.SaveChangesAsync();
        
        return Results.Ok();
    })
    .WithName("UpdateInteraction")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}