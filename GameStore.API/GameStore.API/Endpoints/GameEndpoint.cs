using GameStore.API.Entities;

namespace GameStore.API.Endpoints;

public static class GameEndpoint
{
    static List<Game> games =
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

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var gameGroup = routes.MapGroup("/games").WithParameterValidation();    

        gameGroup.MapGet("/", () => games)
            .WithName("GetGames").WithOpenApi();

        gameGroup.MapGet("/{id}", (int id) =>
        {
            var game = games.FirstOrDefault(g => g.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        }).WithName("GetGameById").WithOpenApi();

        gameGroup.MapPost("/", (Game game) =>
        {
            game.Id = games.Max(g => g.Id) + 1;
            games.Add(game);
            return Results.CreatedAtRoute("GetGameById", new { id = game.Id }, game);
        }).WithName("CreateGame").WithOpenApi();

        gameGroup.MapPut("/{id}", (int id, Game game) =>
        {
            var existingGame = games.FirstOrDefault(g => g.Id == id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = game.Name;
            existingGame.Genre = game.Genre;
            existingGame.Price = game.Price;
            existingGame.ImageUri = game.ImageUri;
            existingGame.UpdatedAt = DateTime.Now;

            return Results.NoContent();
        }).WithName("UpdateGame").WithOpenApi();

        gameGroup.MapDelete("/{id}", (int id) =>
        {
            Game? existingGame = games.FirstOrDefault(g => g.Id == id);
    
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            games.Remove(existingGame);   
            return Results.NoContent();
        }).WithName("DeleteGame").WithOpenApi();

        return gameGroup;
    }
}