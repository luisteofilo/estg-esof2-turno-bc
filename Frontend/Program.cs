using Frontend.Components;
using Frontend.Helpers;
using Frontend.Services; 
using Helpers;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(EnvFileHelper.GetString("API_URL")) });
builder.Services.AddScoped<ApiHelper>();
builder.Services.AddScoped<WineLeaderboardService>();
builder.Services.AddScoped<RegionService>();
builder.Services.AddScoped<UserLeaderboardService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<TasteQuestionService>();
builder.Services.AddScoped<TasteEvaluationQuestionService>();
builder.Services.AddScoped<TasteQuestionTypeService>();
builder.Services.AddScoped<TasteEvaluationService>();
builder.Services.AddScoped<WineService>();
builder.Services.AddScoped<UserService>();

// Adicionar suporte para ProtectedSessionStorage
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();