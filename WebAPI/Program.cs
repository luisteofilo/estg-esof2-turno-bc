using ESOF.WebApp.DBLayer.Context;
using ESOF.WebApp.WebAPI.Helpers;
using ESOF.WebApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext com a string de conexão do appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Adicionar serviços ao contêiner
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar UserService como serviço scoped
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configurar o pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoint de exemplo para obter e-mails dos usuários
app.MapGet("/users/emails", async ([FromServices] ApplicationDbContext db) =>
{
    var users = await db.Users.Select(u => new { u.Email }).ToListAsync();
    return users;
})
.WithName("GetUsersEmails")
.WithOpenApi();

// Endpoint para obter o perfil do usuário logado
app.MapGet("/user/profile", async ([FromServices] ApplicationDbContext db, [FromServices] UserService userService) =>
{
    var userId = UserState.LoggedInUserId ?? Guid.Empty;
    if (userId == Guid.Empty)
    {
        return Results.Unauthorized();
    }

    var userProfile = await userService.GetUserProfileAsync(userId);
    return Results.Ok(userProfile);
})
.WithName("GetUserProfile")
.WithOpenApi();

app.Run();
