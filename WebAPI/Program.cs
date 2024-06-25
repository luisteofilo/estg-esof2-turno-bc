using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.DBLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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


app.MapGet("/wines/average-ratings/{eventId:guid}", (Guid eventId) =>
    {
        using var db = new ApplicationDbContext();
        var wineRatings = db.TasteEvaluations
            .Where(te => te.EventId == eventId)  
            .GroupBy(te => te.WineId)
            .Select(g => new
            {
                WineId = g.Key,
                WineName = g.Select(te => te.Wine.label).FirstOrDefault(),
                AverageScore = g.Average(te => te.WineScore)
            })
            .OrderByDescending(w => w.AverageScore)
            .ToList();

        return wineRatings;
    })
    .WithName("GetWinesAverageRatingsByEvent")
    .WithOpenApi();

app.MapGet("/questions/yesno-results/{eventId:guid}", (Guid eventId) =>
    {
        using var db = new ApplicationDbContext();
        var questionResults = db.TasteEvaluationQuestions
            .Where(teq => teq.TasteQuestion.EventId == eventId && teq.TasteQuestion.QuestionType.Type == "Yes/No")
            .GroupBy(teq => new { teq.TasteQuestionId, teq.TasteQuestion.Questions })
            .Select(g => new
            {
                QuestionId = g.Key.TasteQuestionId,
                Question = g.Key.Questions,
                TotalResponses = g.Count(),
                YesCount = g.Count(teq => teq.Value == "Yes"),
                NoCount = g.Count(teq => teq.Value == "No"),
                YesPercentage = Math.Round((double)g.Count(teq => teq.Value == "Yes") / g.Count() * 100, 2),
                NoPercentage = Math.Round((double)g.Count(teq => teq.Value == "No") / g.Count() * 100, 2)
            })
            .ToList();

        return questionResults;
    })
    .WithName("GetYesNoQuestionResultsByEvent")
    .WithOpenApi();

app.MapGet("/questions/multiple-choice-results/{eventId:guid}", (Guid eventId) =>
    {
        using var db = new ApplicationDbContext();

        var questionResults = db.TasteEvaluationQuestions
            .Where(teq => teq.TasteQuestion.EventId == eventId && teq.TasteQuestion.QuestionType.Type == "Multiple Choice")
            .GroupBy(teq => new { teq.TasteQuestionId, teq.TasteQuestion.Questions })
            .Select(g => new
            {
                QuestionId = g.Key.TasteQuestionId,
                Question = g.Key.Questions,
                TotalResponses = g.Count(),
                Options = g.GroupBy(teq => new { teq.TasteQuestionOption.TasteQuestionOptionId, teq.TasteQuestionOption.OptionText })
                    .Select(g2 => new
                    {
                        OptionId = g2.Key.TasteQuestionOptionId,
                        OptionText = g2.Key.OptionText,
                        CountOption = g2.Count(),
                    })
                    .ToList()
            })
            .ToList();

        return questionResults;

    })
    .WithName("GetMultipleChoiceQuestionResultsByEvent")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}