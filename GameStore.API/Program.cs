using GameStore.API.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Game> games =
[
    new Game()
    {
        Id = 1,
        Name = "The Legend of Zelda: Breath of the Wild",
        Genre = "Action-adventure",
        Price = 59.99m,
        ImageUri = "https://placeholder.co/300",
    },

    new Game()
    {
        Id = 2,
        Name = "Super Mario Odyssey",
        Genre = "Platformer",
        Price = 59.99m,
        ImageUri = "https://placeholder.co/300",
    },

    new Game()
    {
        Id = 3,
        Name = "Mario Kart 8 Deluxe",
        Genre = "Racing",
        Price = 59.99m,
        ImageUri = "https://placeholder.co/300",
    },

    new Game()
    {
        Id = 4,
        Name = "Splatoon 2",
        Genre = "Shooter",
        Price = 59.99m,
        ImageUri = "https://placeholder.co/300",
    }
];

app.MapGet("/games", () => games)
    .WithName("GetGames");

app.MapGet("games/{id}", (int id) => games.FirstOrDefault(g => g.Id == id))
    .WithName("GetGameById");

app.MapGet("/", () => "Hello World!");

app.Run();
