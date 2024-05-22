using GameStore.API.Entities;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

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

app.MapGet("/games/{id}", (int id) => games.FirstOrDefault(g => g.Id == id))
    .WithName("GetGameById");

app.MapPost("/games", (Game game) =>
{
    game.Id = games.Max(g => g.Id) + 1;
    games.Add(game);
    return Results.CreatedAtRoute("GetGameById", new { id = game.Id }, game);
}).WithName("CreateGame");

app.MapGet("/", () => "Hello World!");

app.Run();
