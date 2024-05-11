using GameStore.API.Entities;

List<Game> games = new()
{
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
};


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
