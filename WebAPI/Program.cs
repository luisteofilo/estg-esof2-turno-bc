using ESOF.WebApp.DBLayer.Context;
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
