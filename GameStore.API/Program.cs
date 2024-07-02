
using GameStore.API.Endpoints;
using GameStore.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IInMemGameRepository, InMemGameRepository>();

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
