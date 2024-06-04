using GameStore.API.Endpoints;
using GameStore.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGamesRepository, GamesRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conString = builder.Configuration.GetConnectionString("GameStoreContext");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGamesEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();